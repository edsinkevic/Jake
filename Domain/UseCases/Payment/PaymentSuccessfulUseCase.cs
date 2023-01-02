using Domain.Models;
using Domain.Repositories.Payment;

namespace Domain.UseCases.Payment;

public class PaymentSuccessfulUseCase
{
    private readonly IPaymentRepository _payments;

    public PaymentSuccessfulUseCase(IPaymentRepository payments)
    {
        _payments = payments;
    }

    public async Task Execute(long paymentId)
    {
        await _payments.SetStatus(paymentId, PaymentStatus.Paid);
    }
}