using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using WebBanSach.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebBanSach.Controllers
{
    public class BookController : Controller
    {
        private readonly BookstoreDbContext context;

        public BookController(BookstoreDbContext context)
        {
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
        public IActionResult BookDetail(int id)
        {
            try
            {
                var book = context.Books.Include(b => b.Category).FirstOrDefault(b => b.BookId == id);
                if (book == null)
                {
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}
