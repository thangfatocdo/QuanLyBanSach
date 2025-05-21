using Microsoft.AspNetCore.Mvc;
using AIGoiYSanPham.Models;

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
        public IActionResult Recommend(int userId, int topN = 5)
        {
            // Lấy toàn bộ BookId
            var allIds = _db.Books.Select(b => b.BookId);
            var recs = _svc.Recommend(userId, allIds, topN);
            // recs là List<(int ProductId, float Score)>
            var idsOnly = recs.Select(x => x.BookId).ToList();

            return Ok(idsOnly);
        }
    }
}
