using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using WebBanSach.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebBanSach.Controllers
{
    public class BookController : Controller
    {
        private readonly BookstoreDbContext context;
        private readonly AiRecommendationClient _recService;
        public BookController(BookstoreDbContext context, AiRecommendationClient recService)
        {
            _recService = recService;
            this.context = context;
        }
        [Route("shop.html", Name = "BookShop")]
        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 13;
                var lsBooks = context.Books.AsNoTracking().OrderByDescending(x => x.BookId);
                PagedList<Book> models = new PagedList<Book>(lsBooks, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{Alias}", Name = "CatListBook")]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var lsBooks = context.Books.AsNoTracking().
                    Where(x => x.CategoryId == danhmuc.CategoryId).
                    OrderByDescending(x => x.CreatedAt);
                PagedList<Book> models = new PagedList<Book>(lsBooks, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{id}.html", Name = "BookDetails")] //gán đường dẫn bên view index
        public async Task<IActionResult> BookDetail(int id)
        {
            try
            {
                var book = context.Books.Include(b => b.Category).Include(b => b.Author).Include(b => b.Publisher).FirstOrDefault(b => b.BookId == id);
                if (book == null)
                {
                    return RedirectToAction("Index");
                }

                // Lấy userId từ Claims (nếu chưa login -> không recommend)
                var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!int.TryParse(userIdStr, out var userId))
                {
                    // Trả về view với model rỗng
                    return View(new List<Book>());
                }

                // Lấy danh sách sách gợi ý
                if (userIdStr != null)
                {
                    // Gọi AI gợi ý
                    var recIds = await _recService.RecommendAsync(userId, 10);
                    // Lấy sách tương ứng
                    var recBooks = context.Books.Where(b => recIds.Contains(b.BookId)).ToList();
                    ViewBag.RecommendBooks = recBooks;
                }

                return View(book);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }



        }
        [HttpPost("api/upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { fileName });
        }
    }
}