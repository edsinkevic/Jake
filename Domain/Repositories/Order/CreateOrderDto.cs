using Domain.Models;

namespace Domain.Repositories.Order;

public class CreateOrderDto
{
    public long CustomerId { get; set; }
    public List<long> ProductIds { get; set; } = null!;
    public PaymentType PaymentType { get; set; }
}