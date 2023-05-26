
using Server.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    public decimal TotalPrice => CartItems.Sum(ci => ci.TotalPrice);
}