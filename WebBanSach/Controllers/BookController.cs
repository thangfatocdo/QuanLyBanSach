using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System.Data.Entity;
using WebBanSach.Models;
using WebBanSach.Models.Entities;

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
                var pageSize = 10;
                var lsBooks = context.Books.AsNoTracking().OrderByDescending(x => x.CreatedAt);
                PagedList<Book> models = new PagedList<Book>(lsBooks, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;
                return View(models);
            }
            catch 
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{Alias}-{id}", Name = "ListBook")]
        public IActionResult List(int id, int page=1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = context.Categories.Find(id);
                var lsBooks = context.Books.AsNoTracking().
                    Where(c => c.CategoryId == id).
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
        [Route("/{Alias}-{id}.html", Name = "BookDetails")]
        public IActionResult BookDetail(int id)
        {
            try
            {
                var book = context.Books.Include(c => c.Category).FirstOrDefault(b => b.BookId == id);
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
