using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;

public class ImageService : IImageService
{
    private readonly ApplicationDbContext _context;

    public ImageService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Image> AddImageAsync(Image image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image));

        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();

        return image;
    }

    public async Task<IEnumerable<Image>> GetAllImagesAsync()
    {
        return await _context.Images.ToListAsync();
    }

    public async Task<Image> GetImageByIdAsync(int id)
    {
        var image = await _context.Images.FindAsync(id);

        if (image == null)
            throw new Exception($"No image found with ID: {id}");

        return image;
    }

    public async Task<Image> UpdateImageAsync(Image image)
    {
        var existingImage = await _context.Images.FindAsync(image.Id);

        if (existingImage == null)
            throw new Exception($"No image found with ID: {image.Id}");

        _context.Entry(existingImage).CurrentValues.SetValues(image);
        await _context.SaveChangesAsync();

        return existingImage;
    }

    public async Task DeleteImageAsync(int id)
    {
        var image = await _context.Images.FindAsync(id);

        if (image == null)
            throw new Exception($"No image found with ID: {id}");

        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
    }
}
