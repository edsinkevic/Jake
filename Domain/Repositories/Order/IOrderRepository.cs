using Domain.Models;
using Domain.UseCases.Order;

namespace Domain.Repositories.Order;

public interface IOrderRepository
{
    public Task<Models.Order> Create(CreateOrderDto dto);
    public Task SetStatus(long dtoOrderId, OrderStatus status);
    public Task SetEmployee(long dtoEmployeeId);
    public Task<List<Models.Order>> List();
}