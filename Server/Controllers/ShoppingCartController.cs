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
        private readonly IProductService _productService;

        public ShoppingCartController(IShoppingCartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateCart()
        {
            try
            {
                var shoppingCart = await _cartService.CreateCartAsync();

                return Ok("Shopping cart created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating the shopping cart: {ex.Message}");
            }
        }


        [HttpPost("add/{productId}")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);
                if (product == null)
                {
                    return NotFound($"Product not found with ID: {productId}");
                }

                await _cartService.AddProductToCartAsync(productId);

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
