namespace Server.Models.Dto;

public class CartItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public ProductDto Product { get; set; }
}
