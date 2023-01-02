using Domain.Models;

namespace Domain.Repositories.Payment;

public class CreatePaymentDto
{
    public long OrderId { get; set; }
    public PaymentType PaymentType { get; set; }
}