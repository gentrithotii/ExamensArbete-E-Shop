namespace Server.Models.Dto;

public class CartItemDTO
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductDTO Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}