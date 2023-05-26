namespace Server.Models.Dto;

public class OrderDTO
{
    public int Id { get; set; }
    public List<OrderItemDTO> OrderItems { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}