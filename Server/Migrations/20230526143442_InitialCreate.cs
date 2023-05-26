using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_OrderItem_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Powerful gaming laptop", "Laptop", 1200.50m },
                    { 2, "Latest smartphone model", "Smartphone", 850.99m },
                    { 3, "Wireless headphones", "Headphones", 200.00m },
                    { 4, "Stylish smart watch", "Smart Watch", 250.00m },
                    { 5, "DSLR camera", "Camera", 1500.00m },
                    { 6, "High resolution computer monitor", "Monitor", 300.00m },
                    { 7, "Fast multi-core processor", "Processor", 400.00m },
                    { 8, "Ergonomic backlit keyboard", "Keyboard", 120.00m },
                    { 9, "Wireless optical mouse", "Mouse", 60.00m },
                    { 10, "All-in-one printer with WiFi", "Printer", 220.00m },
                    { 11, "High-speed router with VPN support", "Router", 140.00m },
                    { 12, "Bluetooth speakers with deep bass", "Speakers", 180.00m },
                    { 13, "High resolution 10-inch tablet", "Tablet", 400.00m },
                    { 14, "Studio-quality microphone", "Microphone", 250.00m },
                    { 15, "64GB USB 3.0 Flash Drive", "USB Stick", 30.00m },
                    { 16, "1080p Full HD Webcam", "Webcam", 80.00m },
                    { 17, "4K Smart TV", "TV", 1000.00m },
                    { 18, "Next-generation gaming console", "Game Console", 500.00m },
                    { 19, "Camera drone with 4K recording", "Drone", 800.00m },
                    { 20, "Immersive VR headset with controllers", "Virtual Reality Headset", 600.00m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?auto=format&fit=crop&w=1000&q=60" },
                    { 2, 2, "https://images.unsplash.com/photo-1556656793-08538906a9f8?auto=format&fit=crop&w=1000&q=60" },
                    { 3, 3, "https://images.unsplash.com/photo-1546890975-7596e98cdb30?auto=format&fit=crop&w=1000&q=60" },
                    { 4, 4, "https://images.unsplash.com/photo-1570303345330-e69cff50aee8?auto=format&fit=crop&w=1000&q=60" },
                    { 5, 5, "https://images.unsplash.com/photo-1562564055-71e051d33c59?auto=format&fit=crop&w=1000&q=60" },
                    { 6, 6, "https://images.unsplash.com/photo-1588196749597-9ff075ee6b5b?auto=format&fit=crop&w=1000&q=60" },
                    { 7, 7, "https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?auto=format&fit=crop&w=1000&q=60" },
                    { 8, 8, "https://images.unsplash.com/photo-1549923743-8005b4e42154?auto=format&fit=crop&w=1000&q=60" },
                    { 9, 9, "https://images.unsplash.com/photo-1580427734708-587488d65e7a?auto=format&fit=crop&w=1000&q=60" },
                    { 10, 10, "https://images.unsplash.com/photo-1518364538800-6bae3c2ea0f2?auto=format&fit=crop&w=1000&q=60" },
                    { 11, 11, "https://images.unsplash.com/photo-1580910051074-3eb694886505?auto=format&fit=crop&w=1000&q=60" },
                    { 12, 12, "https://images.unsplash.com/photo-1561089627-56590939b465?auto=format&fit=crop&w=1000&q=60" },
                    { 13, 13, "https://images.unsplash.com/photo-1542744173-05336fcc7ad4?auto=format&fit=crop&w=1000&q=60" },
                    { 14, 14, "https://images.unsplash.com/photo-1582750351356-5fa5db9251ee?auto=format&fit=crop&w=1000&q=60" },
                    { 15, 15, "https://images.unsplash.com/photo-1581267598278-4e2cd46b8746?auto=format&fit=crop&w=1000&q=60" },
                    { 16, 16, "https://images.unsplash.com/photo-1507908708918-77954bb7a79d?auto=format&fit=crop&w=1000&q=60" },
                    { 17, 17, "https://images.unsplash.com/photo-1567603676562-5d690e4e6f91?auto=format&fit=crop&w=1000&q=60" },
                    { 18, 18, "https://images.unsplash.com/photo-1503891450247-ee5f8ec46dc3?auto=format&fit=crop&w=1000&q=60" },
                    { 19, 19, "https://images.unsplash.com/photo-1516387938699-a93567a1988e?auto=format&fit=crop&w=1000&q=60" },
                    { 20, 20, "https://images.unsplash.com/photo-1524578339099-e987812bcca1?auto=format&fit=crop&w=1000&q=60" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderItemId",
                table: "OrderItem",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
