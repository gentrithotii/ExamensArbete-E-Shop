using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ShoppingCartService : IShoppingCartService
{
    private readonly ApplicationDbContext _context;

    public ShoppingCartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShoppingCart> CreateCartAsync()
    {
        var shoppingCart = new ShoppingCart();

        _context.ShoppingCarts.Add(shoppingCart);
        await _context.SaveChangesAsync();

        return shoppingCart;
    }


    public async Task<ShoppingCart> GetCartAsync()
    {
        var shoppingCart = await _context.ShoppingCarts
            .Include(sc => sc.CartItems)
                .ThenInclude(ci => ci.Product)
                    .ThenInclude(p => p.Images)
            .FirstOrDefaultAsync();

        if (shoppingCart == null)
        {
            throw new Exception("No shopping carts exist.");
        }

        return shoppingCart;
    }

    public async Task AddProductToCartAsync(int productId, int quantity)
    {
        var shoppingCart = await GetCartAsync();

        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            throw new Exception($"Product not found with ID: {productId}");
        }

        var existingCartItem = shoppingCart.CartItems.FirstOrDefault(ci => ci.Product.Id == productId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += quantity;
        }
        else
        {
            var newCartItem = new CartItem
            {
                ProductId = productId,
                Product = product,
                Quantity = quantity,
            };
            shoppingCart.CartItems.Add(newCartItem);
        }

        await _context.SaveChangesAsync();
    }


    public async Task<Order> CreateOrderFromCartAsync()
    {
        var shoppingCart = await GetCartAsync();

        if (!shoppingCart.CartItems.Any())
        {
            throw new Exception("Shopping cart is empty");
        }

        var orderItems = shoppingCart.CartItems.Select(ci => new OrderItem
        {
            ProductId = ci.ProductId,
            Quantity = ci.Quantity,
            Price = ci.Product.Price
        }).ToList();

        var order = new Order
        {
            OrderItems = orderItems,
            TotalPrice = shoppingCart.TotalPrice
        };

        _context.Orders.Add(order);
        await ClearCartAsync();

        await _context.SaveChangesAsync();

        return order;
    }

    public async Task RemoveProductFromCartAsync(int productId)
    {
        var shoppingCart = await GetCartAsync();

        var existingCartItem = shoppingCart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (existingCartItem != null)
        {
            if (existingCartItem.Quantity > 1)
            {
                existingCartItem.Quantity -= 1;
            }
            else
            {
                shoppingCart.CartItems.Remove(existingCartItem);
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task ClearCartAsync()
    {
        var shoppingCart = await GetCartAsync();

        shoppingCart.CartItems.Clear();

        await _context.SaveChangesAsync();
    }
}
