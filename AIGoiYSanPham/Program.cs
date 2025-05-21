using AIGoiYSanPham.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);

var argsList = args?.ToList() ?? new List<string>();

// CONSOLETEST: run "dotnet run -- console" thì chạy console rồi exit
if (argsList.Contains("console"))
{
    Console.WriteLine("Chay Console Test Recommendation…");

    // 1) Tạo DbContext
    var options = new DbContextOptionsBuilder<BookstoreDbContext>()
        .UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB"))
        .Options;
    using var db = new BookstoreDbContext(options);

    // 2) Train + load model
    var trainer = new RecommenderTrainer(db);
    trainer.TrainModelFromDb();
    var svc = new RecommenderService(trainer, db);

    // 3) Lấy test user (ví dụ 4) và chạy Recommend
    var userId = 4;
    var allBookIds = db.Books.Select(b => b.BookId).ToList();
    var recs = svc.Recommend(userId, allBookIds, topN: 10);

    // 4) In ra console
    Console.WriteLine($"Recommendations for user {userId}:");
    foreach (var (bookId, score) in recs)
        Console.WriteLine($"  BookId: {bookId}, Score: {score}");

    return;  // exit chương trình
} 

// 1) Đăng ký DbContext EF Core cho BookstoreDB
builder.Services.AddDbContext<BookstoreDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB")));

// 2) Đăng ký trainer & service
builder.Services.AddScoped<RecommenderTrainer>();
builder.Services.AddScoped<RecommenderService>();
// Đăng ký MVC controller
builder.Services.AddControllers();
var app = builder.Build();

// 3) Endpoint retrain model
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    // Mục tiêu: map controller route
    endpoints.MapControllers();
});

app.Run();