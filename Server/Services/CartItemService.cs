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

    public async Task<CartItem> AddCartItemAsync(CartItem cartItem)
    {
        if (cartItem == null)
            throw new ArgumentNullException(nameof(cartItem));

        await _context.CartItems.AddAsync(cartItem);
        await _context.SaveChangesAsync();

        return cartItem;
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
