using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Employee;
using Domain.Repositories.Order;

namespace Domain.UseCases.Order;

public class ConfirmOrderUseCase
{
    private readonly IOrderRepository _orders;
    private readonly IEmployeeRepository _employees;

    public ConfirmOrderUseCase(IOrderRepository orders, IEmployeeRepository employees)
    {
        _orders = orders;
        _employees = employees;
    }

    public async Task Execute(ConfirmOrderDto dto)
    {
        await _orders.SetEmployee(dto.EmployeeId);
        await _orders.SetStatus(dto.OrderId, OrderStatus.InProgress);
    }
}

public class ConfirmOrderDto
{
    public long EmployeeId { get; set; }
    public long OrderId { get; set; }
}