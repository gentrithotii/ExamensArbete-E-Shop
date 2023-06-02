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

        public async Task<OrderDTO> AddOrderAsync(OrderDTO orderDto, IEnumerable<OrderItemDTO> orderItemDtos)
        {
            var order = _mapper.Map<Order>(orderDto);
            var orderItems = _mapper.Map<List<OrderItem>>(orderItemDtos);

            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            if (orderItems == null)
            {
                throw new ArgumentNullException(nameof(orderItems));
            }

            foreach (var item in orderItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    throw new Exception($"Product with id: {item.ProductId} not found.");
                }

                item.Product = product;
                order.OrderItems.Add(item);
                order.TotalPrice += item.Quantity * product.Price;
            }

            var orderEntity = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            var cartItemsToDelete = _context.CartItems.Where(c => orderItems.Select(oi => oi.ProductId).Contains(c.ProductId));
            _context.CartItems.RemoveRange(cartItemsToDelete);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(orderEntity.Entity);
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

        public async Task<OrderDTO> UpdateOrderAsync(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            var existingOrder = await _context.Orders.FindAsync(order.Id);

            if (existingOrder == null)
                throw new Exception($"No order found with ID: {order.Id}");

            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(existingOrder);
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
