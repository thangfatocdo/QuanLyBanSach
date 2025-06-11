using AIGoiYSanPham.Entities;
using AIGoiYSanPham.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);
var argsList = args?.ToList() ?? new List<string>();

// CONSOLETEST: run "dotnet run -- console" thì chạy console rồi exit
if (argsList.Contains("console"))
{
    Console.WriteLine("=== AI GOI Y SACH – CONSOLE TEST ===");

    var options = new DbContextOptionsBuilder<BookstoreDbContext>()
        .UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB"))
        .Options;
    using var db = new BookstoreDbContext(options);

    var trainer = new RecommenderTrainer(db);
    Console.WriteLine(" Training mo hinh tu du lieu thuc...");
    trainer.TrainModelFromDb();
    var svc = new RecommenderService(trainer, db);

    var userId = 19; // test user
    var allBookIds = db.Books.Select(b => b.BookId).ToList();
    var recs = svc.Recommend(userId, allBookIds, topN: 10);

    var valid = recs.Where(x => !float.IsNaN(x.Score)).ToList();
    Console.WriteLine($"\n=== GOI Y CHO USER {userId} (Normalized 0–10) ===");

    if (!valid.Any())
    {
        Console.WriteLine(" khong có goi y nao (toàn NaN) – user co the chua tung mua sach.");
    }
    else
    {
        var min = valid.Min(x => x.Score);
        var max = valid.Max(x => x.Score);
        foreach (var (bookId, score) in valid)
        {
            var norm = max > min ? (score - min) / (max - min) * 10f : 10f;
            Console.WriteLine($" BookId: {bookId}, Score: {norm:0.000}");
        }
    }

    Console.WriteLine("\n=== KET THUC ===");
    return;
}

// ----------------- Tạo app web ----------------- //

// 1) DbContext
builder.Services.AddDbContext<BookstoreDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB")));

// 2) AI services
builder.Services.AddScoped<RecommenderTrainer>();
builder.Services.AddScoped<RecommenderService>();

// 3) Razor + Controller support
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 4) Middleware
app.UseStaticFiles(); // nếu có ảnh / css
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
