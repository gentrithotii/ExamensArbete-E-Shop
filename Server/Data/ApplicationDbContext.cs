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
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, Name = "Laptop", Description = "Powerful gaming laptop", Price = 1200.50M },
    new Product { Id = 2, Name = "Smartphone", Description = "Latest smartphone model", Price = 850.99M },
    new Product { Id = 3, Name = "Headphones", Description = "Wireless headphones", Price = 200.00M },
    new Product { Id = 4, Name = "Smart Watch", Description = "Stylish smart watch", Price = 250.00M },
    new Product { Id = 5, Name = "Camera", Description = "DSLR camera", Price = 1500.00M },
    new Product { Id = 6, Name = "Monitor", Description = "High resolution computer monitor", Price = 300.00M },
    new Product { Id = 7, Name = "Processor", Description = "Fast multi-core processor", Price = 400.00M },
    new Product { Id = 8, Name = "Keyboard", Description = "Ergonomic backlit keyboard", Price = 120.00M },
    new Product { Id = 9, Name = "Mouse", Description = "Wireless optical mouse", Price = 60.00M },
    new Product { Id = 10, Name = "Printer", Description = "All-in-one printer with WiFi", Price = 220.00M },
    new Product { Id = 11, Name = "Router", Description = "High-speed router with VPN support", Price = 140.00M },
    new Product { Id = 12, Name = "Speakers", Description = "Bluetooth speakers with deep bass", Price = 180.00M },
    new Product { Id = 13, Name = "Tablet", Description = "High resolution 10-inch tablet", Price = 400.00M },
    new Product { Id = 14, Name = "Microphone", Description = "Studio-quality microphone", Price = 250.00M },
    new Product { Id = 15, Name = "USB Stick", Description = "64GB USB 3.0 Flash Drive", Price = 30.00M },
    new Product { Id = 16, Name = "Webcam", Description = "1080p Full HD Webcam", Price = 80.00M },
    new Product { Id = 17, Name = "TV", Description = "4K Smart TV", Price = 1000.00M },
    new Product { Id = 18, Name = "Game Console", Description = "Next-generation gaming console", Price = 500.00M },
    new Product { Id = 19, Name = "Drone", Description = "Camera drone with 4K recording", Price = 800.00M },
    new Product { Id = 20, Name = "Virtual Reality Headset", Description = "Immersive VR headset with controllers", Price = 600.00M }
);
        modelBuilder.Entity<Image>().HasData(
  new Image { Id = 1, Url = "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?auto=format&fit=crop&w=1000&q=60", ProductId = 1 }, // Laptop
  new Image { Id = 2, Url = "https://images.unsplash.com/photo-1556656793-08538906a9f8?auto=format&fit=crop&w=1000&q=60", ProductId = 2 }, // Smartphone
  new Image { Id = 3, Url = "https://images.unsplash.com/photo-1546890975-7596e98cdb30?auto=format&fit=crop&w=1000&q=60", ProductId = 3 }, // Headphones
  new Image { Id = 4, Url = "https://images.unsplash.com/photo-1570303345330-e69cff50aee8?auto=format&fit=crop&w=1000&q=60", ProductId = 4 }, // Smart Watch
  new Image { Id = 5, Url = "https://images.unsplash.com/photo-1562564055-71e051d33c59?auto=format&fit=crop&w=1000&q=60", ProductId = 5 }, // Camera
  new Image { Id = 6, Url = "https://images.unsplash.com/photo-1588196749597-9ff075ee6b5b?auto=format&fit=crop&w=1000&q=60", ProductId = 6 }, // Monitor
  new Image { Id = 7, Url = "https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?auto=format&fit=crop&w=1000&q=60", ProductId = 7 }, // Processor
  new Image { Id = 8, Url = "https://images.unsplash.com/photo-1549923743-8005b4e42154?auto=format&fit=crop&w=1000&q=60", ProductId = 8 }, // Keyboard
  new Image { Id = 9, Url = "https://images.unsplash.com/photo-1580427734708-587488d65e7a?auto=format&fit=crop&w=1000&q=60", ProductId = 9 }, // Mouse
  new Image { Id = 10, Url = "https://images.unsplash.com/photo-1518364538800-6bae3c2ea0f2?auto=format&fit=crop&w=1000&q=60", ProductId = 10 }, // Printer
  new Image { Id = 11, Url = "https://images.unsplash.com/photo-1580910051074-3eb694886505?auto=format&fit=crop&w=1000&q=60", ProductId = 11 }, // Router
  new Image { Id = 12, Url = "https://images.unsplash.com/photo-1561089627-56590939b465?auto=format&fit=crop&w=1000&q=60", ProductId = 12 }, // Speakers
  new Image { Id = 13, Url = "https://images.unsplash.com/photo-1542744173-05336fcc7ad4?auto=format&fit=crop&w=1000&q=60", ProductId = 13 }, // Tablet
  new Image { Id = 14, Url = "https://images.unsplash.com/photo-1582750351356-5fa5db9251ee?auto=format&fit=crop&w=1000&q=60", ProductId = 14 }, // Microphone
  new Image { Id = 15, Url = "https://images.unsplash.com/photo-1581267598278-4e2cd46b8746?auto=format&fit=crop&w=1000&q=60", ProductId = 15 }, // USB Stick
  new Image { Id = 16, Url = "https://images.unsplash.com/photo-1507908708918-77954bb7a79d?auto=format&fit=crop&w=1000&q=60", ProductId = 16 }, // Webcam
  new Image { Id = 17, Url = "https://images.unsplash.com/photo-1567603676562-5d690e4e6f91?auto=format&fit=crop&w=1000&q=60", ProductId = 17 }, // TV
  new Image { Id = 18, Url = "https://images.unsplash.com/photo-1503891450247-ee5f8ec46dc3?auto=format&fit=crop&w=1000&q=60", ProductId = 18 }, // Game console
  new Image { Id = 19, Url = "https://images.unsplash.com/photo-1516387938699-a93567a1988e?auto=format&fit=crop&w=1000&q=60", ProductId = 19 }, // Drone
  new Image { Id = 20, Url = "https://images.unsplash.com/photo-1524578339099-e987812bcca1?auto=format&fit=crop&w=1000&q=60", ProductId = 20 }  // Virtual Reality Headset
);

        modelBuilder.Entity<ShoppingCart>().HasData(
            new ShoppingCart { Id = 1 }
        );
        modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, ProductId = 1, Quantity = 1, ShoppingCartId = 1 },
            new CartItem { Id = 2, ProductId = 2, Quantity = 2, ShoppingCartId = 1 },
            new CartItem { Id = 3, ProductId = 3, Quantity = 3, ShoppingCartId = 1 },
            new CartItem { Id = 4, ProductId = 4, Quantity = 4, ShoppingCartId = 1 },
            new CartItem { Id = 5, ProductId = 5, Quantity = 5, ShoppingCartId = 1 }
        );

        // modelBuilder.Entity<ShoppingCart>()
        //        .Ignore(b => b.TotalPrice);


    }

}