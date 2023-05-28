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
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Laptop", 1200.50m },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Smartphone", 850.99m },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Headphones", 200.00m },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Smart Watch", 250.00m },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Camera", 1500.00m },
                    { 6, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Monitor", 300.00m },
                    { 7, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Processor", 400.00m },
                    { 8, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Keyboard", 120.00m },
                    { 9, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Mouse", 60.00m },
                    { 10, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Printer", 220.00m },
                    { 11, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Router", 140.00m },
                    { 12, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Speakers", 180.00m },
                    { 13, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Tablet", 400.00m },
                    { 14, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Microphone", 250.00m },
                    { 15, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "USB Stick", 30.00m },
                    { 16, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Webcam", 80.00m },
                    { 17, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "TV", 1000.00m },
                    { 18, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Game Console", 500.00m },
                    { 19, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Drone", 800.00m },
                    { 20, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi porttitor dolor eu tellus rutrum, eget pharetra nunc porttitor. Sed non erat consectetur, eleifend urna in, accumsan tellus. Quisque finibus libero est, eu posuere libero facilisis nec. Aenean malesuada, arcu in blandit fringilla, sem quam feugiat justo, ac dapibus justo nibh at justo. Nam id condimentum purus. Praesent dictum vitae ex eget dignissim. Vestibulum blandit ac metus a ullamcorper. Nulla in scelerisque ante, ac venenatis lacus. Quisque lobortis cursus feugiat. Integer mollis purus mollis lacus pharetra tempus. Sed tempus purus eget enim maximus, a pharetra mauris tincidunt. Donec tincidunt dignissim sem, non pretium nibh tristique sit amet. Praesent at arcu at nulla commodo pellentesque. Suspendisse tristique libero id dui pulvinar porta. In dictum tempus odio, vitae lobortis mauris pharetra ac.", "Virtual Reality Headset", 600.00m }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?auto=format&fit=crop&w=1000&q=60" },
                    { 2, 2, "https://images.unsplash.com/photo-1556656793-08538906a9f8?auto=format&fit=crop&w=1000&q=60" },
                    { 3, 3, "https://www.energysistem.com/cdnassets/products/45305/principal_2000.jpg" },
                    { 4, 4, "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8U21hcnQlMjB3YXRjaHxlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=400&q=60" },
                    { 5, 5, "https://images.unsplash.com/photo-1552168324-d612d77725e3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8Y2FtZXJhfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60" },
                    { 6, 6, "https://images.unsplash.com/photo-1588196749597-9ff075ee6b5b?auto=format&fit=crop&w=1000&q=60" },
                    { 7, 7, "https://images.unsplash.com/photo-1593642533144-3d62aa4783ec?auto=format&fit=crop&w=1000&q=60" },
                    { 8, 8, "https://images.unsplash.com/photo-1561112078-7d24e04c3407?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTd8fGtleWJvYXJkfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60" },
                    { 9, 9, "https://images.unsplash.com/photo-1563297007-0686b7003af7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MjN8fG1vdXNlfGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60" },
                    { 10, 10, "https://images.unsplash.com/photo-1518364538800-6bae3c2ea0f2?auto=format&fit=crop&w=1000&q=60" },
                    { 11, 11, "https://images.unsplash.com/photo-1580910051074-3eb694886505?auto=format&fit=crop&w=1000&q=60" },
                    { 12, 12, "https://images.unsplash.com/photo-1545454675-3531b543be5d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8U3BlYWtlcnN8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&w=400&q=60" },
                    { 13, 13, "https://images.unsplash.com/photo-1542744173-05336fcc7ad4?auto=format&fit=crop&w=1000&q=60" },
                    { 14, 14, "https://images.unsplash.com/photo-1580493783887-8c874c534e93?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTh8fG1pY3xlbnwwfHwwfHx8MA%3D%3D&auto=format&fit=crop&w=400&q=60" },
                    { 15, 15, "https://images.unsplash.com/photo-1618324068162-431429ed0df2?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=774&q=80" },
                    { 16, 16, "https://images.unsplash.com/photo-1623949556303-b0d17d198863?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80" },
                    { 17, 17, "https://images.unsplash.com/photo-1573399054516-90665ecc44be?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1375&q=80" },
                    { 18, 18, "https://images.unsplash.com/photo-1531390658120-e06b58d826ea?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTJ8fFBsYXlzdGF0aW9ufGVufDB8fDB8fHww&auto=format&fit=crop&w=400&q=60" },
                    { 19, 19, "https://images.unsplash.com/photo-1612455130176-00d76a2f613f?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1364&q=80" },
                    { 20, 20, "https://images.unsplash.com/photo-1514499007249-cd680c1d1060?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1470&q=80" },
                    { 21, 1, "https://picsum.photos/500/700" },
                    { 22, 1, "https://picsum.photos/500/700" },
                    { 23, 1, "https://picsum.photos/500/700" },
                    { 24, 2, "https://picsum.photos/500/700" },
                    { 25, 2, "https://picsum.photos/500/700" },
                    { 26, 2, "https://picsum.photos/500/700" },
                    { 27, 3, "https://picsum.photos/500/700" },
                    { 28, 3, "https://picsum.photos/500/700" },
                    { 29, 3, "https://picsum.photos/500/700" },
                    { 30, 4, "https://picsum.photos/500/700" },
                    { 31, 4, "https://picsum.photos/500/700" },
                    { 32, 4, "https://picsum.photos/500/700" },
                    { 33, 5, "https://picsum.photos/500/700" },
                    { 34, 5, "https://picsum.photos/500/700" },
                    { 35, 5, "https://picsum.photos/500/700" },
                    { 36, 6, "https://picsum.photos/500/700" },
                    { 37, 6, "https://picsum.photos/500/700" },
                    { 38, 6, "https://picsum.photos/500/700" },
                    { 39, 7, "https://picsum.photos/500/700" },
                    { 40, 7, "https://picsum.photos/500/700" },
                    { 41, 7, "https://picsum.photos/500/700" },
                    { 42, 8, "https://picsum.photos/500/700" },
                    { 43, 8, "https://picsum.photos/500/700" },
                    { 44, 8, "https://picsum.photos/500/700" },
                    { 45, 9, "https://picsum.photos/500/700" },
                    { 46, 9, "https://picsum.photos/500/700" },
                    { 47, 9, "https://picsum.photos/500/700" },
                    { 48, 10, "https://picsum.photos/500/700" },
                    { 49, 10, "https://picsum.photos/500/700" },
                    { 50, 10, "https://picsum.photos/500/700" }
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
