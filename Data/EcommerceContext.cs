using EcommerceInventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceInventoryApi.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed data for testing
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Gadgets and devices" },
                new Category { Id = 2, Name = "Books", Description = "Printed and digital reading material" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, StockQuantity = 10, CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", Price = 599.50m, StockQuantity = 25, CategoryId = 1 },
                new Product { Id = 3, Name = "Programming C#", Price = 45.00m, StockQuantity = 50, CategoryId = 2 }
            );
        }
    }
}