using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IProductService
{
    Task<Product> AddProductAsync(Product product);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}

