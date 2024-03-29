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

    public async Task AddProductToCartAsync(int productId)
    {
        var shoppingCart = await GetCartAsync();

        if (shoppingCart == null)
        {
            shoppingCart = new ShoppingCart();
            _context.ShoppingCarts.Add(shoppingCart);
        }

        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            throw new Exception($"Product not found with ID: {productId}");
        }

        var existingCartItem = shoppingCart.CartItems.FirstOrDefault(ci => ci.Product.Id == productId);
        if (existingCartItem != null)
        {
            existingCartItem.Quantity += 1;
        }
        else
        {
            var newCartItem = new CartItem
            {
                ProductId = productId,
                Product = product,
                Quantity = 1,
            };
            shoppingCart.CartItems.Add(newCartItem);
        }

        await _context.SaveChangesAsync();
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

        _context.CartItems.RemoveRange(shoppingCart.CartItems);
        shoppingCart.CartItems.Clear();

        await _context.SaveChangesAsync();
    }
}
