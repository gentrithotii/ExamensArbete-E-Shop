using Server.Models.Dto;

namespace Server.Services.InterfacesServices
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrderAsync(OrderDTO orderDto, IEnumerable<OrderItemDTO> orderItemDtos);
        Task<OrderDTO> CreateOrderFromCartAsync(int cartId);
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO> GetOrderByIdAsync(int id);
        Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDto);
        Task DeleteOrderAsync(int id);
    }
}
