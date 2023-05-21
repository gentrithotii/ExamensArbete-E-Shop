using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IOrderService
{
    Task<Order> AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
}