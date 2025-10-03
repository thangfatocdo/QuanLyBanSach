using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBanSach.Models.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Model;
using WebBanSach.Models.Entities;

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
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<RecommendationDto> recItems;
            List<Book> recBooks;

            if (int.TryParse(userIdStr, out var userId))
            {
                try
                {
                    // 1) Gọi AI
                    recItems = await _recService.RecommendAsync(userId);

                    // 2) Lấy chi tiết sách
                    var ids = recItems.Select(r => r.BookId).ToList();
                    var rawBooks = context.Books
                        .Include(b => b.BookImages)
                        .Where(b => ids.Contains(b.BookId))
                        .ToList();

                    // 3) Sắp xếp theo Score
                    recBooks = recItems
                        .Join(rawBooks,
                              rec => rec.BookId,
                              book => book.BookId,
                              (rec, book) => new { Book = book, Score = rec.Score })
                        .OrderByDescending(x => x.Score)
                        .Select(x => x.Book)
                        .ToList();
                }
                catch (Exception)
                {
                    // Fallback nếu AI lỗi: lấy sách có rating cao
                    recItems = null;
                    recBooks = context.BookRatings
                        .Where(r => r.RatingValue != null)
                        .GroupBy(r => r.BookId)
                        .Select(g => new
                        {
                            BookId = g.Key,
                            AvgRating = g.Average(r => r.RatingValue)
                        })
                        .OrderByDescending(x => x.AvgRating)
                        .Take(10)
                        .Join(context.Books.Include(b => b.BookImages),
                              x => x.BookId, b => b.BookId, (x, b) => b)
                        .ToList();
                }
            }
            else
            {
                // fallback khi chưa login
                recItems = null;
                recBooks = context.BookRatings
                    .Where(r => r.RatingValue != null)
                    .GroupBy(r => r.BookId)
                    .Select(g => new
                    {
                        BookId = g.Key,
                        AvgRating = g.Average(r => r.RatingValue)
                    })
                    .OrderByDescending(x => x.AvgRating)
                    .Take(10)
                    .Join(context.Books.Include(b => b.BookImages),
                          x => x.BookId, b => b.BookId, (x, b) => b)
                    .ToList();
            }

            ViewBag.RecommendItems = recItems;    // List<RecommendationDto> or null
            ViewBag.RecommendBooks = recBooks;    // List<Book>
            ViewBag.BookRatings = context.BookRatings.ToList();
            ViewBag.TopRatedBooks = context.Books
                .Include(b => b.BookImages)
                .OrderByDescending(b => b.BookRatings.Average(r => r.RatingValue))
                .Take(10)
                .ToList();

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
