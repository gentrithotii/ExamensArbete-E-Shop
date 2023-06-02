using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;
using Server.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ThenInclude(p => p.Images).ToListAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }


        public async Task<OrderDTO> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                throw new Exception($"No order found with ID: {id}");

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                throw new Exception($"No order found with ID: {id}");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDTO> CreateOrderFromCartAsync(int cartId)
        {
            var shoppingCart = await _context.ShoppingCarts.Include(sc => sc.CartItems).ThenInclude(ci => ci.Product).ThenInclude(i => i.Images).FirstOrDefaultAsync(sc => sc.Id == cartId);

            if (shoppingCart == null)
            {
                throw new Exception($"Shopping cart not found with ID: {cartId}");
            }

            if (!shoppingCart.CartItems.Any())
            {
                throw new Exception("Shopping cart is empty");
            }

            var orderItems = shoppingCart.CartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Price = ci.Product.Price
            }).ToList();

            var order = new Order
            {
                OrderItems = orderItems,
                OrderDate = DateTime.Now,
                TotalPrice = shoppingCart.TotalPrice
            };

            _context.Orders.Add(order);


            shoppingCart.CartItems.Clear();
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }
    }
}
