using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IUserService
{
    Task<User> CreateUserAsync();
    Task<User> UpdateUserAsync();
}