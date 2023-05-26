// using Microsoft.AspNetCore.Mvc;
// using Server.Models;
// using Server.Services;
// using Server.Services.InterfacesServices;

// [ApiController]
// [Route("api/[controller]")]
// public class CartItemsController : ControllerBase
// {
//     private readonly ICartItemService _cartItemService;

//     public CartItemsController(ICartItemService cartItemService)
//     {
//         _cartItemService = cartItemService;
//     }

//     [HttpPost]
//     public async Task<IActionResult> AddCartItem(int productId)
//     {
//         try
//         {

//             if (productId <= 0)
//                 return BadRequest("Invalid product ID");

//             var createdCartItem = await _cartItemService.AddCartItemAsync(productId);


//             if (createdCartItem == null)
//                 return BadRequest("CartItem could not be created");

//             return CreatedAtAction(nameof(GetCartItem), new { id = createdCartItem.Id }, createdCartItem);
//         }
//         catch (ArgumentException)
//         {

//             return BadRequest("Invalid argument. Please provide a valid product ID.");
//         }
//         catch (Exception)
//         {

//             return StatusCode(500, "An error occurred while creating the CartItem. Please try again later.");
//         }
//     }


//     [HttpGet]
//     public async Task<IActionResult> GetAllCartItems()
//     {
//         var cartItems = await _cartItemService.GetAllCartItemsAsync();
//         return Ok(cartItems);
//     }

//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetCartItem(int id)
//     {
//         try
//         {
//             var cartItem = await _cartItemService.GetCartItemByIdAsync(id);
//             return Ok(cartItem);
//         }
//         catch (Exception e)
//         {
//             return NotFound(e.Message);
//         }
//     }

//     [HttpPut("{id}")]
//     public async Task<IActionResult> UpdateCartItem(int id, [FromBody] CartItem cartItem)
//     {
//         if (id != cartItem.Id)
//             return BadRequest();

//         try
//         {
//             var updatedCartItem = await _cartItemService.UpdateCartItemAsync(cartItem);
//             return Ok(updatedCartItem);
//         }
//         catch (Exception e)
//         {
//             return NotFound(e.Message);
//         }
//     }

//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteCartItem(int id)
//     {
//         try
//         {
//             await _cartItemService.DeleteCartItemAsync(id);
//             return NoContent();
//         }
//         catch (Exception e)
//         {
//             return NotFound(e.Message);
//         }
//     }
// }
