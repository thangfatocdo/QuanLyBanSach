using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBanSach.Models.ViewModels;
using WebBanSach.Models.Entities;
using System.Security.Claims;

namespace WebBanSach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookstoreDbContext context;
        private readonly AiRecommendationClient _recService;



        public HomeController(ILogger<HomeController> logger, BookstoreDbContext context, AiRecommendationClient recService)
        {
            _logger = logger;
            this.context = context;
            _recService = recService;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy userId từ Claims (nếu chưa login -> không recommend)
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))
            {
                // Trả về view với model rỗng
                return View(new List<Book>());
            }

            // Gọi AI gợi ý
            var recIds = await _recService.RecommendAsync(userId, 5);
            // Lấy sách tương ứng
            var recBooks = context.Books.Where(b => recIds.Contains(b.BookId)).ToList();
            ViewBag.RecommendBooks = recBooks;
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
