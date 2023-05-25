using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;

namespace Server.Services;

public class CartItemService : ICartItemService
{
    private readonly ApplicationDbContext _context;

    public CartItemService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CartItem> AddCartItemAsync(int productId)
    {
        var cartItem = new CartItem();
        var product = await _context.Products.FindAsync(productId);

        if (product == null)
            throw new ArgumentException("Invalid product ID");

        var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += 1;
        }
        else
        {
            cartItem = new CartItem
            {
                ProductId = product.Id,
                Quantity = 1
            };

            await _context.CartItems.AddAsync(cartItem);
        }

        await _context.SaveChangesAsync();

        return existingCartItem ?? cartItem;
    }


    public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
    {
        return await _context.CartItems.Include(c => c.Product).ThenInclude(p => p.Images).ToListAsync();
    }

    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        var cartItem = await _context.CartItems.Include(c => c.Product).ThenInclude(p => p.Images).FirstOrDefaultAsync(c => c.Id == id);

        if (cartItem == null)
            throw new Exception($"No cart item found with ID: {id}");

        return cartItem;
    }

    public async Task<CartItem> UpdateCartItemAsync(CartItem cartItem)
    {
        var existingCartItem = await _context.CartItems.FindAsync(cartItem.Id);

        if (existingCartItem == null)
            throw new Exception($"No cart item found with ID: {cartItem.Id}");

        _context.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
        await _context.SaveChangesAsync();

        return existingCartItem;
    }

    public async Task DeleteCartItemAsync(int id)
    {
        var cartItem = await _context.CartItems.FindAsync(id);

        if (cartItem == null)
            throw new Exception($"No cart item found with ID: {id}");

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
    }
}
