using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopFuji.Areas.Identity.Data;

namespace ShopFuji.Data;
public class ShopFujiDbContext : IdentityDbContext<ShopFujiAuthUser>
{
    public ShopFujiDbContext(DbContextOptions<ShopFujiDbContext> options)
        : base(options)
    {
    }


	public DbSet<ShopFuji.Models.Product> Products { get; set; } = default!;
	public DbSet<ShopFuji.Models.Image> Images { get; set; } = default!;
	public DbSet<ShopFuji.Models.CartItem> CartItems { get; set; } = default!;


	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
