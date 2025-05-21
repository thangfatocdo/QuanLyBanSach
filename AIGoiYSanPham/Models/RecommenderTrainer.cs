using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using AIGoiYSanPham.Models;   // Cho BookRating, BookstoreDbContext

namespace AIGoiYSanPham.Models
{
    public class RecommenderTrainer
    {
        private readonly string _modelPath = Path.Combine("wwwroot", "models", "book-recommender.zip");
        private readonly MLContext _mlContext;
        private readonly BookstoreDbContext _db;

        public RecommenderTrainer(BookstoreDbContext db)
        {
            _db = db;
            _mlContext = new MLContext(seed: 0);
        }

        public void TrainModelFromDb()
        {
            // 1) Load data từ DB
            var ratings = _db.OrderItems
               .Where(oi => oi.Order.CustomerId != null)
               .GroupBy(oi => new { oi.Order.CustomerId, oi.BookId })
               .Select(g => new BookRating
               {
                   UserId = (uint)g.Key.CustomerId.Value,
                   BookId = (uint)g.Key.BookId,
                   Label = g.Sum(x => (float)x.BookQuantity)
               })
               .ToList();

            if (!ratings.Any())
                throw new InvalidOperationException("Không có dữ liệu OrderItems để train.");

            // 2) Chuyển thành IDataView
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(ratings);

            // 3) Chia train/test
            var split = _mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            // 4) Xây pipeline: map UserId/BookId → key, rồi append MatrixFactorization
            var pipeline = _mlContext.Transforms.Conversion
                .MapValueToKey(outputColumnName: "userIndex", inputColumnName: nameof(BookRating.UserId))
                .Append(_mlContext.Transforms.Conversion
                    .MapValueToKey(outputColumnName: "bookIndex", inputColumnName: nameof(BookRating.BookId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    new MatrixFactorizationTrainer.Options
                    {
                        MatrixColumnIndexColumnName = "userIndex",
                        MatrixRowIndexColumnName    = "bookIndex",
                        LabelColumnName             = nameof(BookRating.Label),
                        NumberOfIterations          = 20,
                        ApproximationRank           = 100
                    }));

            // 5) Huấn luyện
            var model = pipeline.Fit(split.TrainSet);
            

            // 6) Lưu model (dùng schema gốc để chứa key mapping)
            Directory.CreateDirectory(Path.GetDirectoryName(_modelPath)!);
            using var fs = File.Create(_modelPath);
            _mlContext.Model.Save(model, dataView.Schema, fs);
        }

        public ITransformer LoadModel()
        {
            if (!File.Exists(_modelPath))
                TrainModelFromDb();

            using var fs = File.OpenRead(_modelPath);
            return _mlContext.Model.Load(fs, out _);
        }
    }
}
