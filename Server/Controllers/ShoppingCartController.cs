using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services.InterfacesServices;


namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCart()
        {
            try
            {
                var shoppingCart = await _cartService.GetCartAsync();
                return Ok(shoppingCart);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving the shopping cart: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] Product product, int quantity)
        {
            try
            {
                await _cartService.AddProductToCartAsync(product, quantity);
                return Ok("Product added to the cart successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the product to the cart: {ex.Message}");
            }
        }

        [HttpDelete("remove/{productId}")]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            try
            {
                await _cartService.RemoveProductFromCartAsync(productId);
                return Ok("Product removed from the cart successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while removing the product from the cart: {ex.Message}");
            }
        }

        [HttpPost("clear")]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                await _cartService.ClearCartAsync();
                return Ok("Cart cleared successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while clearing the cart: {ex.Message}");
            }
        }
    }
}
