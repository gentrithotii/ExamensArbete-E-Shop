using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IUserService
{
    Task<ShoppingCart> CreateUserAsync();
    Task<ShoppingCart> UpdateUserAsync();
}