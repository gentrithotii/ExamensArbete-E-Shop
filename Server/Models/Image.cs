using System.Text.Json.Serialization;

namespace Server.Models;

public class Image
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int ProductId { get; set; }


    [JsonIgnore]
    public Product Product { get; set; }
}