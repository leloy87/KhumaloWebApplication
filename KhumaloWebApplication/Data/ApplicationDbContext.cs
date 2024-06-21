using KhumaloWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KhumaloLibrary;

namespace KhumaloWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Products> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelbuilder.Entity<Order>()
                .Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelbuilder.Entity<OrderItem>()
                .Property(p => p.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelbuilder.Entity<ShoppingCart>()
                .Property(p => p.TotalPrice)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelbuilder);
        }
        public DbSet<KhumaloLibrary.TaskItem> TaskItem { get; set; } = default!;

    }
}
