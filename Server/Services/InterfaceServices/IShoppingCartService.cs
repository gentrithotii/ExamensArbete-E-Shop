using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IShoppingCartService
{
    Task<ShoppingCart> CreateCartAsync();
    Task<ShoppingCart> GetCartAsync();
    Task AddProductToCartAsync(int productId);
    Task RemoveProductFromCartAsync(int productId);
    Task ClearCartAsync();
}