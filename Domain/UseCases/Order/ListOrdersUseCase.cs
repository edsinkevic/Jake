using Domain.Repositories.Order;

namespace Domain.UseCases.Order;

public class ListOrdersUseCase
{
    private readonly IOrderRepository _orderRepository;

    public ListOrdersUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Models.Order>> Execute()
    {
        return await _orderRepository.List();
    }
}