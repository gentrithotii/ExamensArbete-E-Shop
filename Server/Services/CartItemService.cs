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
        // Fetch the product from the database
        var product = await _context.Products.FindAsync(productId);

        // Check if the product exists
        if (product == null)
            throw new ArgumentException("Invalid product ID");

        // Check if a CartItem with this product already exists
        var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId);

        if (existingCartItem != null)
        {
            // If the CartItem already exists, increase the quantity
            existingCartItem.Quantity += 1;
        }
        else
        {
            // If the CartItem does not exist, create a new one
            cartItem = new CartItem
            {
                ProductId = product.Id,
                Quantity = 1  // Set this to the desired initial quantity
                              // Set other CartItem properties as needed
            };

            await _context.CartItems.AddAsync(cartItem);
        }

        // Save the changes to the database
        await _context.SaveChangesAsync();

        // Return the updated or new CartItem
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
