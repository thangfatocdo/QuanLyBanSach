using AIGoiYSanPham.Entities;
using AIGoiYSanPham.Models;
using Microsoft.AspNetCore.Mvc;

namespace AIGoiYSanPham.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookstoreDbContext context;

        public HomeController(BookstoreDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int customerId)
        {
            var allBookIds = context.Books.Select(b => b.BookId).ToList();
            var trainer = new RecommenderTrainer(context);
            var logs = new List<string>();
            logs.Add("=== TRAINING MODEL ===");

            trainer.TrainModelFromDb(); // retrain model
            logs.Add("✓ Huấn luyện thành công!");

            var (testRmse, r2) = trainer.EvaluateModel();
            logs.Add($"📊 RMSE: {testRmse:F4} | R²: {r2:F4}");

            var svc = new RecommenderService(trainer, context);
            logs.Add($"\n=== GỢI Ý CHO USER {customerId} ===");

            var recs = svc.Recommend(customerId, allBookIds, allBookIds.Count);
            var valid = recs.Where(x => !float.IsNaN(x.Score)).ToList();

            if (!valid.Any())
            {
                logs.Add("⚠ Không có gợi ý nào. Có thể user chưa từng mua sách.");
            }
            else
            {
                var min = valid.Min(x => x.Score);
                var max = valid.Max(x => x.Score);

                var result = valid.Select(x => new
                {
                    x.BookId,
                    Score = max > min ? MathF.Round((x.Score - min) / (max - min) * 100f, 2) : 100f
                });

                foreach (var item in result)
                {
                    logs.Add($"BookId: {item.BookId}, Score: {item.Score}%");
                }
            }

            ViewBag.Logs = logs;
            return View();
        }
    }
}
