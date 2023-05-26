using Server.Models.Dto;

namespace Server.Services.InterfacesServices
{
    public interface ICartItemService
    {
        Task<CartItemDTO> AddCartItemAsync(int id);
        Task<IEnumerable<CartItemDTO>> GetAllCartItemsAsync();
        Task<CartItemDTO> GetCartItemByIdAsync(int id);
        Task<CartItemDTO> UpdateCartItemAsync(CartItemDTO cartItemDto);
        Task DeleteCartItemAsync(int id);
    }
}