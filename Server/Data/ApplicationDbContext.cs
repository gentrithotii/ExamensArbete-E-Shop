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
  new Image { Id = 3, Url = "https://www.energysistem.com/cdnassets/products/45305/principal_2000.jpg", ProductId = 3 }, // Headphones
  new Image { Id = 4, Url = "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U21hcnQlMjB3YXRjaHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=400&q=60", ProductId = 4 }, // Smart Watch
  new Image { Id = 5, Url = "https://images.unsplash.com/photo-1552168324-d612d77725e3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Y2FtZXJhfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60", ProductId = 5 }, // Camera
  new Image { Id = 6, Url = "https://images.unsplash.com/photo-1588196749597-9ff075ee6b5b?auto=format&fit=crop&w=1000&q=60", ProductId = 6 }, // Monitor
  new Image { Id = 7, Url = "https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?auto=format&fit=crop&w=1000&q=60", ProductId = 7 }, // Processor
  new Image { Id = 8, Url = "https://images.unsplash.com/photo-1561112078-7d24e04c3407?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGtleWJvYXJkfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60", ProductId = 8 }, // Keyboard
  new Image { Id = 9, Url = "https://images.unsplash.com/photo-1563297007-0686b7003af7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fG1vdXNlfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60", ProductId = 9 }, // Mouse
  new Image { Id = 10, Url = "https://images.unsplash.com/photo-1518364538800-6bae3c2ea0f2?auto=format&fit=crop&w=1000&q=60", ProductId = 10 }, // Printer
  new Image { Id = 11, Url = "https://images.unsplash.com/photo-1580910051074-3eb694886505?auto=format&fit=crop&w=1000&q=60", ProductId = 11 }, // Router
  new Image { Id = 12, Url = "https://images.unsplash.com/photo-1545454675-3531b543be5d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8U3BlYWtlcnN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=400&q=60", ProductId = 12 }, // Speakers
  new Image { Id = 13, Url = "https://images.unsplash.com/photo-1542744173-05336fcc7ad4?auto=format&fit=crop&w=1000&q=60", ProductId = 13 }, // Tablet
  new Image { Id = 14, Url = "https://images.unsplash.com/photo-1580493783887-8c874c534e93?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fG1pY3xlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=400&q=60", ProductId = 14 }, // Microphone
  new Image { Id = 15, Url = "https://images.unsplash.com/photo-1618324068162-431429ed0df2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=774&q=80", ProductId = 15 }, // USB Stick
  new Image { Id = 16, Url = "https://images.unsplash.com/photo-1623949556303-b0d17d198863?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80", ProductId = 16 }, // Webcam
  new Image { Id = 17, Url = "https://images.unsplash.com/photo-1573399054516-90665ecc44be?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1375&q=80", ProductId = 17 }, // TV
  new Image { Id = 18, Url = "https://images.unsplash.com/photo-1531390658120-e06b58d826ea?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fFBsYXlzdGF0aW9ufGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60", ProductId = 18 }, // Game console
  new Image { Id = 19, Url = "https://images.unsplash.com/photo-1612455130176-00d76a2f613f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1364&q=80", ProductId = 19 }, // Drone
  new Image { Id = 20, Url = "https://images.unsplash.com/photo-1514499007249-cd680c1d1060?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80", ProductId = 20 }  // Virtual Reality Headset
);



    }

}