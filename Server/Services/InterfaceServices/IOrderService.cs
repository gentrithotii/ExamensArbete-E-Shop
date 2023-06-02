using Server.Models.Dto;

namespace Server.Services.InterfacesServices
{
    public interface IOrderService
    {
        Task<OrderDTO> CreateOrderFromCartAsync(int cartId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task DeleteOrderAsync(int id);
    }
}
