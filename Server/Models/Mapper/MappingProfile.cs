using AutoMapper;
using Server.Models.Dto;
using Server.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>();
        CreateMap<CartItem, CartItemDTO>();
        CreateMap<Image, ImageDTO>();
        CreateMap<Order, OrderDTO>();
        CreateMap<OrderItem, OrderItemDTO>();
        CreateMap<ShoppingCart, ShoppingCartDTO>();
    }
}
