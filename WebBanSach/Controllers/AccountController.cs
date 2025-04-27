using Microsoft.AspNetCore.Mvc;
using WebBanSach.Models.ViewModels;
using WebBanSach.Models.Entities;
using WebBanSach.Models;

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
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm khách hàng theo email và password
                var customer = context.Customers
                    .FirstOrDefault(c => c.Email == model.Email && c.Password == model.Password);

                if (customer != null)
                {
                    // Lưu thông tin vào session
                    HttpContext.Session.SetInt32("CustomerId", customer.CustomerId);
                    HttpContext.Session.SetString("CustomerName", customer.FullName);

                    // TODO: Nếu muốn xử lý RememberMe thì cần dùng cookie

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
                    return View(model);
                }
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
        public IActionResult Logout()
        {
            // Xoá các session liên quan đến đăng nhập
            HttpContext.Session.Remove("CustomerId");
            HttpContext.Session.Remove("CustomerName");

            // Chuyển hướng về trang chủ
            return RedirectToAction("Index", "Home");
        }


    }
}