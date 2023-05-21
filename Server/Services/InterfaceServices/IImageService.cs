using Server.Models;

namespace Server.Services.InterfacesServices;

public interface IImageService
{
    Task<Image> AddImageAsync(Image image);
    Task<IEnumerable<Image>> GetAllImagesAsync();
    Task<Image> GetImageByIdAsync(int id);
    Task<Image> UpdateImageAsync(Image image);
    Task DeleteImageAsync(int id);
}
