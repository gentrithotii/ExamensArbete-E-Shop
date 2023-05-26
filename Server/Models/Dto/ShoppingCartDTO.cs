using Server.Models.Dto;

public class ShoppingCartDTO
{
    public int Id { get; set; }
    public List<CartItemDTO> CartItems { get; set; }
    public decimal TotalPrice { get; set; }
}