using System.Text.Json.Serialization;

namespace Server.Models;

public class CartItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int ShoppingCartId { get; set; }
    [JsonIgnore]
    public decimal TotalPrice => Quantity * Product.Price;
    [JsonIgnore]
    public ShoppingCart ShoppingCart { get; set; }


}

