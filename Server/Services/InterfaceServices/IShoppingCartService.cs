using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IShoppingCartService
{
    Task<ShoppingCart> GetCartAsync();
    Task AddProductToCartAsync(Product product, int quantity);
    Task RemoveProductFromCartAsync(int productId);
    Task<Order> CreateOrderFromCartAsync();
    Task ClearCartAsync();
}