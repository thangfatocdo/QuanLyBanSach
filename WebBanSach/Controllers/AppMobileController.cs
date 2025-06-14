using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebBanSach.Models.Entities;

namespace WebBanSach.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppMobileController : ControllerBase
    {
        private readonly BookstoreDbContext _context;

        public AppMobileController(BookstoreDbContext context)
        {
            _context = context;
        }

        // GET: api/appmobile/orders
        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Book)
                        .ThenInclude(b => b.BookImages) // để lấy ảnh
                .Include(o => o.Status)
                .OrderByDescending(o => o.OrderDate)
                .Select(o => new
                {
                    o.OrderId,
                    o.OrderDate,
                    StatusName = o.Status.StatusName,
                    o.CustomerName,
                    o.TotalPrice,
                    Items = o.OrderItems.Select(i => new
                    {
                        i.Book.Title,
                        BookPrice = i.BookPrice,
                        BookQuantity = i.BookQuantity,
                        ImageUrl = i.Book.BookImages
                            .OrderBy(img => img.ImageId)
                            .Select(img => img.ImageUrl)
                            .FirstOrDefault() ?? "default.jpg" // fallback nếu không có ảnh
                    })
                })
                .ToListAsync();

            return Ok(orders);
        }
        // GET: api/appmobile/orders/{id}
        [HttpGet("orders/{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(i => i.Book)
                .Include(o => o.Status).Include(o =>o.PaymentMethod)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
                return NotFound();

            var result = new
            {
                order.OrderId,
                order.OrderDate,
                StatusName = order.Status.StatusName,
                order.CustomerName,
                order.Phone,
                order.Address,
                order.PaymentMethod.MethodName,
                order.TotalPrice,
                Items = order.OrderItems.Select(i => new
                {
                    i.Book.Title,
                    i.BookPrice,
                    i.BookQuantity,
                    LineTotal = i.BookPrice * i.BookQuantity
                })
            };

            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Thiếu thông tin đăng nhập." });

            var hashedPassword = PasswordHelper.Hash(request.Password); // dùng cùng logic hash như WinForm

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == hashedPassword);

            if (user == null)
                return Unauthorized(new { message = "Sai tài khoản hoặc mật khẩu." });

            return Ok(new
            {
                user.UserId,
                user.Username,
                user.FullName,
                user.ImageUrl
            });
        }

        [HttpPut("orders/{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStatusDto dto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            var status = await _context.OrderStatuses
                .FirstOrDefaultAsync(s => s.StatusName == dto.NewStatus);

            if (status == null)
                return BadRequest("Trạng thái không hợp lệ.");

            order.StatusId = status.StatusId;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã cập nhật trạng thái thành công" });
        }
        // Thêm API khác nếu cần: Get sách, trạng thái đơn hàng, chi tiết đơn...
    }

}
public class UpdateStatusDto
{
    public string NewStatus { get; set; }
}
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
public static class PasswordHelper
{
    public static string Hash(string raw)
    {
        using (SHA256 sha = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(raw);
            byte[] hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}