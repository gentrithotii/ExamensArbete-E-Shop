using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IShoppingCartService
{
    Task<ShoppingCart> CreateCartAsync();
    Task<ShoppingCart> GetCartAsync();
    Task AddProductToCartAsync(int productId, int quantity);
    Task RemoveProductFromCartAsync(int productId);
    Task ClearCartAsync();
}