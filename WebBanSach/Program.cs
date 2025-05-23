﻿using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.EntityFrameworkCore;
using WebBanSach.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Dang ký RecommendationService duoi dang Singleton
builder.Services.AddSingleton<AiRecommendationClient>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<BookstoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDB")));
builder.Services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

// Thêm cấu hình Authentication bằng cookie
builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // có thể đổi thành 1 ngày
    });

//Đăng ký HttpClient để gọi AI service
builder.Services.AddHttpClient("AIClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/api/recommender/"); // địa chỉ project AI
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseNotyf();
app.UseAuthentication(); // <-- BẮT BUỘC có dòng này
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
