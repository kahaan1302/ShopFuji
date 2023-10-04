using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopFuji.Areas.Identity.Data;
using ShopFuji.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShopFujiDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ShopFujiDbContextConnection' not found.");

builder.Services.AddDbContext<ShopFujiDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ShopFujiAuthUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ShopFujiDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireUppercase = false;
});

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
