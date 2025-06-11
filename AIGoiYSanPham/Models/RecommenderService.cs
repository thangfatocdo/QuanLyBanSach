using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using AIGoiYSanPham.Models;
using AIGoiYSanPham.Entities;

namespace AIGoiYSanPham.Models
{
    public class RecommenderService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;
        private PredictionEngine<BookRatingEntry, BookRatingPrediction> _engine;
        private readonly BookstoreDbContext _db;
        public RecommenderService(RecommenderTrainer trainer, BookstoreDbContext db)
        {
            _db = db;
            _mlContext = new MLContext(seed: 0);
            _model = trainer.LoadModel();
            _engine = _mlContext.Model.CreatePredictionEngine<BookRatingEntry, BookRatingPrediction>(_model);
        }

        // Trả về topN sản phẩm gợi ý cho user
        public List<(int BookId, float Score)> Recommend(int userId, IEnumerable<int> allBookIds, int topN)
        {
            var scores = new List<(int BookId, float Score)>();

            foreach (var bookId in allBookIds)
            {
                var output = _engine.Predict(new BookRatingEntry   
                {
                    UserId = (uint)userId,
                    BookId = (uint)bookId,
                    Label = 0f  // không dùng
                });
                scores.Add((bookId, output.Score));
            }

            return scores
                .OrderByDescending(x => x.Score)
                .Take(topN)
                .ToList();
        }
        // MỚI: trả về tất cả BookId trong DB
        public List<int> GetAllBookIds()
        {
            return _db.Books
                      .Select(b => b.BookId)
                      .ToList();
        }
    }
}
