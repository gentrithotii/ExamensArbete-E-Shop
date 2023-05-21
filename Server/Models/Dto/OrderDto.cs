namespace Server.Models.Dto;

public class OrderDto
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
