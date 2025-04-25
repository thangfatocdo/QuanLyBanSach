using Microsoft.AspNetCore.Mvc;

namespace WebBanSach.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
