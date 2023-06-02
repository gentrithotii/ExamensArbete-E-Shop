using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Models.Dto;
using Server.Services.InterfacesServices;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    private readonly IShoppingCartService _shoppingCartService;

    public OrdersController(IOrderService orderService, IShoppingCartService shoppingCartService)
    {
        _orderService = orderService;
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost("{cartId}")]
    public async Task<IActionResult> AddOrder(int cartId)
    {
        try
        {
            var order = await _orderService.CreateOrderFromCartAsync(cartId);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return CreatedAtAction(nameof(GetOrder),
                new { id = order.Id },
                JsonSerializer.Serialize(order, options));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while adding the order: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        try
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            return Ok(order);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        try
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
