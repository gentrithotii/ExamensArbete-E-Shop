using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Services.InterfacesServices;

namespace Server.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Order> AddOrderAsync(Order order, IEnumerable<OrderItem> orderItems)
    {
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

            order.TotalPrice += item.Quantity * product.Price;
        }

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        var cartItemsToDelete = _context.CartItems.Where(c => orderItems.Select(oi => oi.ProductId).Contains(c.ProductId));
        _context.CartItems.RemoveRange(cartItemsToDelete);
        await _context.SaveChangesAsync();

        return order;
    }


    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        var order = await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            throw new Exception($"No order found with ID: {id}");

        return order;
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        var existingOrder = await _context.Orders.FindAsync(order.Id);

        if (existingOrder == null)
            throw new Exception($"No order found with ID: {order.Id}");

        _context.Entry(existingOrder).CurrentValues.SetValues(order);
        await _context.SaveChangesAsync();

        return existingOrder;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
            throw new Exception($"No order found with ID: {id}");

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}
