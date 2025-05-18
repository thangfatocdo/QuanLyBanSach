using Microsoft.AspNetCore.Mvc;
using WebBanSach.Models.ViewModels;
using WebBanSach.Models.Entities;
using WebBanSach.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Extension;

namespace WebBanSach.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookstoreDbContext context;

        public AccountController(BookstoreDbContext context)
        {
            this.context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModels model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã tồn tại chưa
                var existingCustomer = context.Customers.FirstOrDefault(c => c.Email == model.Email);
                if (existingCustomer != null)
                {
                    ModelState.AddModelError("", "Email đã được đăng ký.");
                    return View(model);
                }

                // Add thong tin vào entity
                var customer = new Customer
                {
                    FullName = model.Name,
                    Email = model.Email,
                    Password = model.Password, // TODO: nên hash nếu triển khai thật
                };

                context.Customers.Add(customer);
                context.SaveChanges();

                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);

                if (customer != null)
                {
                    // Tạo Claims
                    var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, customer.CustomerId.ToString()),
                new Claim(ClaimTypes.Name, customer.FullName),
                new Claim(ClaimTypes.Email, customer.Email)
            };
                    // 1. Xóa session cart cũ
                    HttpContext.Session.Remove("GioHang");

                    // 2. Lấy cart từ DB (CartItems) cho customer này
                    var dbCart = context.CartItems
                        .Include(ci => ci.Book)
                        .Where(ci => ci.CustomerId == customer.CustomerId)
                        .ToList();

                    // 3. Chuyển thành ViewModel
                    var vmCart = dbCart.Select(ci => new CartViewModel
                    {
                        book = ci.Book,
                        amount = (int)ci.Quantity
                    }).ToList();

                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    var principal = new ClaimsPrincipal(identity);

                    // Ghi cookie
                    await HttpContext.SignInAsync("MyCookieAuth", principal, new AuthenticationProperties
                    {
                        IsPersistent = model.RememberMe // từ checkbox
                    });

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
            }

            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}