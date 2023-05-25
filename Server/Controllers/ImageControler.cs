using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.InterfacesServices;


[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddImage([FromBody] Image image)
    {
        if (image == null)
            return BadRequest();

        var createdImage = await _imageService.AddImageAsync(image);
        return CreatedAtAction(nameof(GetImage), new { id = createdImage.Id }, createdImage);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllImages()
    {
        var images = await _imageService.GetAllImagesAsync();
        return Ok(images);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImage(int id)
    {
        try
        {
            var image = await _imageService.GetImageByIdAsync(id);
            return Ok(image);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateImage(int id, [FromBody] Image image)
    {
        if (id != image.Id)
            return BadRequest();

        try
        {
            var updatedImage = await _imageService.UpdateImageAsync(image);
            return Ok(updatedImage);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        try
        {
            await _imageService.DeleteImageAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
