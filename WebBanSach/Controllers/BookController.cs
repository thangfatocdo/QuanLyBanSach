using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebBanSach.Models.Entities;

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
        public IActionResult Index(int? categoryId, int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 8;
                var query = context.Books.AsQueryable();

                // Nếu có lọc theo thể loại
                if (categoryId.HasValue)
                {
                    query = query.Where(b => b.CategoryId == categoryId);
                }

                var models = new PagedList<Book>(
                    query.AsNoTracking().OrderByDescending(b => b.BookId),
                    pageNumber, pageSize
                );

                // Gửi danh sách thể loại và category đang chọn
                var categories = context.Categories.OrderBy(c => c.CategoryName).ToList();
                ViewBag.Categories = categories;
                ViewBag.SelectedCategoryId = categoryId;
                ViewBag.CurrentPage = pageNumber;

                // Lấy danh sách đánh giá cho sách
                var ratings = context.BookRatings
                    .ToList();
                ViewBag.BookRatings = ratings;
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
                    ViewBag.RecommendBooks = new List<Book>();
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

                // Lấy danh sách đánh giá cho sách
                var ratings = context.BookRatings
                    .Include(r => r.Customer)
                    .Where(r => r.BookId == id)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToList();
                ViewBag.BookRatings = ratings;
                // Nếu đã đăng nhập, kiểm tra user đã đánh giá chưa
                if (int.TryParse(userIdStr, out var currentUserId))
                {
                    var myRating = context.BookRatings.FirstOrDefault(r => r.BookId == id && r.CustomerId == currentUserId);
                    ViewBag.MyRating = myRating;
                }

                return View(book);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult SubmitRating(BookRating model)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))
                return RedirectToAction("Login", "Account");

            var existing = context.BookRatings.FirstOrDefault(r => r.BookId == model.BookId && r.CustomerId == userId);
            if (existing != null)
            {
                // Cập nhật
                existing.RatingValue = model.RatingValue;
                existing.Comment = model.Comment;
                existing.CreatedAt = DateTime.Now;
            }
            else
            {
                // Thêm mới
                model.CustomerId = userId;
                model.CreatedAt = DateTime.Now;
                context.BookRatings.Add(model);
            }

            context.SaveChanges();
            return RedirectToRoute("BookDetails", new { id = model.BookId });
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