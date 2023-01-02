using Domain.Models;
using Domain.Repositories.Order;

namespace Domain.UseCases.Order;

public class CompleteOrderUseCase
{
    private readonly IOrderRepository _orders;

    public CompleteOrderUseCase(IOrderRepository orders)
    {
        _orders = orders;
    }

    public async Task Execute(long orderId)
    {
        await _orders.SetStatus(orderId, OrderStatus.Done);
    }
}