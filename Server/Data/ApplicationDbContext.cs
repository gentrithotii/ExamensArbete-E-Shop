using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Image> Images { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "Powerful gaming laptop", Price = 1200.50M },
            new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone model", Price = 850.99M },
            new Product { Id = 3, Name = "Headphones", Description = "Wireless headphones", Price = 200.00M },
            new Product { Id = 4, Name = "Smart Watch", Description = "Stylish smart watch", Price = 250.00M },
            new Product { Id = 5, Name = "Camera", Description = "DSLR camera", Price = 1500.00M }
        );

        modelBuilder.Entity<Image>().HasData(
            new Image { Id = 1, Url = "https://example.com/images/laptop.jpg", ProductId = 1 },
            new Image { Id = 2, Url = "https://example.com/images/smartphone.jpg", ProductId = 2 },
            new Image { Id = 3, Url = "https://example.com/images/headphones.jpg", ProductId = 3 },
            new Image { Id = 4, Url = "https://example.com/images/smart_watch.jpg", ProductId = 4 },
            new Image { Id = 5, Url = "https://example.com/images/camera.jpg", ProductId = 5 }
        );

        modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, ProductId = 1, Quantity = 1 },
            new CartItem { Id = 2, ProductId = 2, Quantity = 2 },
            new CartItem { Id = 3, ProductId = 3, Quantity = 3 },
            new CartItem { Id = 4, ProductId = 4, Quantity = 4 },
            new CartItem { Id = 5, ProductId = 5, Quantity = 5 }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, TotalPrice = 1200.50M },
            new Order { Id = 2, TotalPrice = 1701.98M },
            new Order { Id = 3, TotalPrice = 600.00M },
            new Order { Id = 4, TotalPrice = 1000.00M },
            new Order { Id = 5, TotalPrice = 7500.00M }
        );

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderItem { Id = 2, OrderId = 2, ProductId = 2, Quantity = 2 },
            new OrderItem { Id = 3, OrderId = 3, ProductId = 3, Quantity = 3 },
            new OrderItem { Id = 4, OrderId = 4, ProductId = 4, Quantity = 4 },
            new OrderItem { Id = 5, OrderId = 5, ProductId = 5, Quantity = 5 }
        );

    }

}