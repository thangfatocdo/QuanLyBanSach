using AIGoiYSanPham.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

var builder = WebApplication.CreateBuilder(args);

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
