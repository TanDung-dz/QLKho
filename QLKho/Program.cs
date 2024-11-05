using Microsoft.EntityFrameworkCore;
using QLKho.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString =
builder.Configuration.GetConnectionString("WebsiteQLKhohangConnection");
builder.Services.AddDbContext<QlkhoHangContext>(options =>
 options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	name: "trang-chu",
	pattern: "trang-chu",
	defaults: new { controller = "Home", action = "Index" });

	endpoints.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
	 name: "dang-ky",
	 pattern: "dang-ky",
	 defaults: new { controller = "User", action = "Register" });

    endpoints.MapControllerRoute(
 name: "dang-nhap",
 pattern: "dang-nhap",
 defaults: new { controller = "User", action = "Login" });

});
app.Run();
