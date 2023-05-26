﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230526130859_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Server.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Quantity = 1,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Quantity = 2,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Quantity = 3,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Quantity = 4,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Quantity = 5,
                            ShoppingCartId = 1
                        });
                });

            modelBuilder.Entity("Server.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            Url = "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 2,
                            Url = "https://images.unsplash.com/photo-1556656793-08538906a9f8?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 3,
                            Url = "https://images.unsplash.com/photo-1546890975-7596e98cdb30?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 4,
                            Url = "https://images.unsplash.com/photo-1570303345330-e69cff50aee8?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 5,
                            Url = "https://images.unsplash.com/photo-1562564055-71e051d33c59?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 6,
                            Url = "https://images.unsplash.com/photo-1588196749597-9ff075ee6b5b?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 7,
                            Url = "https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 8,
                            Url = "https://images.unsplash.com/photo-1549923743-8005b4e42154?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 9,
                            ProductId = 9,
                            Url = "https://images.unsplash.com/photo-1580427734708-587488d65e7a?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 10,
                            ProductId = 10,
                            Url = "https://images.unsplash.com/photo-1518364538800-6bae3c2ea0f2?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 11,
                            ProductId = 11,
                            Url = "https://images.unsplash.com/photo-1580910051074-3eb694886505?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 12,
                            ProductId = 12,
                            Url = "https://images.unsplash.com/photo-1561089627-56590939b465?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 13,
                            ProductId = 13,
                            Url = "https://images.unsplash.com/photo-1542744173-05336fcc7ad4?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 14,
                            ProductId = 14,
                            Url = "https://images.unsplash.com/photo-1582750351356-5fa5db9251ee?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 15,
                            ProductId = 15,
                            Url = "https://images.unsplash.com/photo-1581267598278-4e2cd46b8746?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 16,
                            ProductId = 16,
                            Url = "https://images.unsplash.com/photo-1507908708918-77954bb7a79d?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 17,
                            ProductId = 17,
                            Url = "https://images.unsplash.com/photo-1567603676562-5d690e4e6f91?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 18,
                            ProductId = 18,
                            Url = "https://images.unsplash.com/photo-1503891450247-ee5f8ec46dc3?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 19,
                            ProductId = 19,
                            Url = "https://images.unsplash.com/photo-1516387938699-a93567a1988e?auto=format&fit=crop&w=1000&q=60"
                        },
                        new
                        {
                            Id = 20,
                            ProductId = 20,
                            Url = "https://images.unsplash.com/photo-1524578339099-e987812bcca1?auto=format&fit=crop&w=1000&q=60"
                        });
                });

            modelBuilder.Entity("Server.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Server.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderItemId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Server.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Powerful gaming laptop",
                            Name = "Laptop",
                            Price = 1200.50m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Latest smartphone model",
                            Name = "Smartphone",
                            Price = 850.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Wireless headphones",
                            Name = "Headphones",
                            Price = 200.00m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Stylish smart watch",
                            Name = "Smart Watch",
                            Price = 250.00m
                        },
                        new
                        {
                            Id = 5,
                            Description = "DSLR camera",
                            Name = "Camera",
                            Price = 1500.00m
                        },
                        new
                        {
                            Id = 6,
                            Description = "High resolution computer monitor",
                            Name = "Monitor",
                            Price = 300.00m
                        },
                        new
                        {
                            Id = 7,
                            Description = "Fast multi-core processor",
                            Name = "Processor",
                            Price = 400.00m
                        },
                        new
                        {
                            Id = 8,
                            Description = "Ergonomic backlit keyboard",
                            Name = "Keyboard",
                            Price = 120.00m
                        },
                        new
                        {
                            Id = 9,
                            Description = "Wireless optical mouse",
                            Name = "Mouse",
                            Price = 60.00m
                        },
                        new
                        {
                            Id = 10,
                            Description = "All-in-one printer with WiFi",
                            Name = "Printer",
                            Price = 220.00m
                        },
                        new
                        {
                            Id = 11,
                            Description = "High-speed router with VPN support",
                            Name = "Router",
                            Price = 140.00m
                        },
                        new
                        {
                            Id = 12,
                            Description = "Bluetooth speakers with deep bass",
                            Name = "Speakers",
                            Price = 180.00m
                        },
                        new
                        {
                            Id = 13,
                            Description = "High resolution 10-inch tablet",
                            Name = "Tablet",
                            Price = 400.00m
                        },
                        new
                        {
                            Id = 14,
                            Description = "Studio-quality microphone",
                            Name = "Microphone",
                            Price = 250.00m
                        },
                        new
                        {
                            Id = 15,
                            Description = "64GB USB 3.0 Flash Drive",
                            Name = "USB Stick",
                            Price = 30.00m
                        },
                        new
                        {
                            Id = 16,
                            Description = "1080p Full HD Webcam",
                            Name = "Webcam",
                            Price = 80.00m
                        },
                        new
                        {
                            Id = 17,
                            Description = "4K Smart TV",
                            Name = "TV",
                            Price = 1000.00m
                        },
                        new
                        {
                            Id = 18,
                            Description = "Next-generation gaming console",
                            Name = "Game Console",
                            Price = 500.00m
                        },
                        new
                        {
                            Id = 19,
                            Description = "Camera drone with 4K recording",
                            Name = "Drone",
                            Price = 800.00m
                        },
                        new
                        {
                            Id = 20,
                            Description = "Immersive VR headset with controllers",
                            Name = "Virtual Reality Headset",
                            Price = 600.00m
                        });
                });

            modelBuilder.Entity("ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("Server.Models.CartItem", b =>
                {
                    b.HasOne("Server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShoppingCart", "ShoppingCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("Server.Models.Image", b =>
                {
                    b.HasOne("Server.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Server.Models.OrderItem", b =>
                {
                    b.HasOne("Server.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Models.OrderItem", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderItemId");

                    b.HasOne("Server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Server.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Server.Models.OrderItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Server.Models.Product", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}