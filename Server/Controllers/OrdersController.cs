using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.InterfacesServices;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ICartItemService _cartItemService;
    private readonly IShoppingCartService _shoppingCartService;
    public OrdersController(IOrderService orderService, ICartItemService cartItemService, IShoppingCartService shoppingCartService)
    {
        _orderService = orderService;
        _cartItemService = cartItemService;
        _shoppingCartService = shoppingCartService;

    }
    // [HttpPost]
    // public async Task<IActionResult> AddOrder()
    // {
    //     try
    //     {
    //         IEnumerable<CartItem> cartItems = await _cartItemService.GetAllCartItemsAsync();

    //         if (!cartItems.Any())
    //         {
    //             return BadRequest("No cart items found.");
    //         }

    //         List<OrderItem> orderItems = cartItems.Select(item => new OrderItem
    //         {
    //             ProductId = item.ProductId,
    //             Quantity = item.Quantity
    //         }).ToList();

    //         Order order = new Order
    //         {
    //             OrderItems = orderItems
    //         };
    //         var options = new JsonSerializerOptions
    //         {
    //             ReferenceHandler = ReferenceHandler.Preserve,
    //             WriteIndented = true
    //         };
    //         var createdOrder = await _orderService.AddOrderAsync(order, orderItems);
    //         return CreatedAtAction(nameof(GetOrder),
    //         new { id = createdOrder.Id },
    //         JsonSerializer.Serialize(createdOrder, options));
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"An error occurred while adding the order: {ex.Message}");
    //     }
    // }


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
    [HttpPost]
    public async Task<IActionResult> AddOrder()
    {
        try
        {
            var order = await _shoppingCartService.CreateOrderFromCartAsync();
            var createdOrder = await _orderService.AddOrderAsync(order, order.OrderItems);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return CreatedAtAction(nameof(GetOrder),
                new { id = createdOrder.Id },
                JsonSerializer.Serialize(createdOrder, options));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while adding the order: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
    {
        if (id != order.Id)
            return BadRequest();

        try
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(order);
            return Ok(updatedOrder);
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
