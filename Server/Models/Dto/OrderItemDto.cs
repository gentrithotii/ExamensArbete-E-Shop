namespace Server.Models.Dto;

public class OrderItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public ProductDto Product { get; set; }
}
