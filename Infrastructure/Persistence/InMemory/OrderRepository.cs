using Domain.Models;
using Domain.Repositories.Order;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.InMemory;

public class OrderRepository : IOrderRepository
{
    private readonly InMemoryDbContext _context;

    public OrderRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Order> Create(CreateOrderDto dto)
    {
        var order = new Data.Order { CustomerId = dto.CustomerId, Status = OrderStatus.Pending };
        await _context.Orders.AddAsync(order);
        return order.ToDomain();
    }

    public async Task SetStatus(long dtoOrderId, OrderStatus status)
    {
        var order = await _context.Orders.FindAsync(dtoOrderId);
        if (order == null)
            return;

        order.Status = status;
        _context.Attach(order);
        await _context.SaveChangesAsync();
    }

    public Task SetEmployee(long dtoEmployeeId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Order>> List()
    {
        var orders = await _context.Orders.ToListAsync();
        return orders.Select(order => order.ToDomain()).ToList();
    }
}