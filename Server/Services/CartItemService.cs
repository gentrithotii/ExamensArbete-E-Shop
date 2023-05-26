using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;
using Server.Models.Dto;

namespace Server.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CartItemService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartItemDTO> AddCartItemAsync(int productId)
        {
            var cartItem = new CartItem();
            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                throw new ArgumentException("Invalid product ID");

            var existingCartItem = await _context.CartItems.FirstOrDefaultAsync(ci => ci.ProductId == productId);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
            }
            else
            {
                cartItem = new CartItem
                {
                    ProductId = product.Id,
                    Quantity = 1
                };

                await _context.CartItems.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDTO>(existingCartItem ?? cartItem);
        }

        public async Task<IEnumerable<CartItemDTO>> GetAllCartItemsAsync()
        {
            var cartItems = await _context.CartItems.Include(c => c.Product).ThenInclude(p => p.Images).ToListAsync();
            return _mapper.Map<IEnumerable<CartItemDTO>>(cartItems);
        }

        public async Task<CartItemDTO> GetCartItemByIdAsync(int id)
        {
            var cartItem = await _context.CartItems.Include(c => c.Product).ThenInclude(p => p.Images).FirstOrDefaultAsync(c => c.Id == id);

            if (cartItem == null)
                throw new Exception($"No cart item found with ID: {id}");

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async Task<CartItemDTO> UpdateCartItemAsync(CartItemDTO cartItemDto)
        {
            var cartItem = _mapper.Map<CartItem>(cartItemDto);
            var existingCartItem = await _context.CartItems.FindAsync(cartItem.Id);

            if (existingCartItem == null)
                throw new Exception($"No cart item found with ID: {cartItem.Id}");

            _context.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<CartItemDTO>(existingCartItem);
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            if (cartItem == null)
                throw new Exception($"No cart item found with ID: {id}");

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }
    }
}
