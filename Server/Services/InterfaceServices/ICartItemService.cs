using Server.Models;

namespace Server.Services.InterfacesServices;

public interface ICartItemService
{
    Task<CartItem> AddCartItemAsync(int id);
    Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
    Task<CartItem> GetCartItemByIdAsync(int id);
    Task<CartItem> UpdateCartItemAsync(CartItem cartItem);
    Task DeleteCartItemAsync(int id);
}
