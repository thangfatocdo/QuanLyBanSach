using Microsoft.AspNetCore.Mvc;
using AIGoiYSanPham.Models;
using AIGoiYSanPham.Entities;

namespace AIGoiYSanPham.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommenderController : ControllerBase
    {
        private readonly RecommenderTrainer _trainer;
        private readonly RecommenderService _svc;
        private readonly BookstoreDbContext _db;

        public RecommenderController(
            RecommenderTrainer trainer,
            RecommenderService svc, BookstoreDbContext db)
        {
            _trainer = trainer;
            _svc = svc;
            _db = db;
        }

        // POST api/recommender/retrain
        [HttpPost("retrain")]
        public IActionResult Retrain()
        {
            _trainer.TrainModelFromDb();
            return Ok(new { success = true, msg = "Model retrained" });
        }

        // GET api/recommender/recommend?userId=4&topN=5
        [HttpGet("recommend")]
        public IActionResult Recommend(int userId, int topN = int.MaxValue)
        {
            // 1. Lấy toàn bộ sách
            var allBookIds = _db.Books.Select(b => b.BookId).ToList();

            // 2. Dự đoán điểm cho toàn bộ sách
            var fullRecs = _svc.Recommend(userId, allBookIds, allBookIds.Count);

            // 3. Nếu tất cả đều NaN → fallback theo đánh giá
            if (fullRecs.All(x => float.IsNaN(x.Score)))
            {
                var fallback = _db.BookRatings
                    .GroupBy(x => x.BookId)
                    .Select(g => new RecommendationDto
                    {
                        BookId = g.Key,
                        Score = (float)g.Average(x => x.RatingValue ?? 0)
                    })
                    .OrderByDescending(x => x.Score)
                    .Take(topN)
                    .ToList();

                return Ok(fallback);
            }

            // 4. Normalize theo full list
            var valid = fullRecs.Where(x => !float.IsNaN(x.Score)).ToList();
            var min = valid.Min(x => x.Score);
            var max = valid.Max(x => x.Score);

            var normalized = valid
                .Select(x => new RecommendationDto
                {
                    BookId = x.BookId,
                    Score = max > min
                        ? (x.Score - min) / (max - min) * 100f
                        : 100f
                })
                .OrderByDescending(x => x.Score)
                .Take(topN)
                .ToList();

            return Ok(normalized);
        }


    }
}
public class RecommendationDto
{
    public int BookId { get; set; }
    public float Score { get; set; }
}