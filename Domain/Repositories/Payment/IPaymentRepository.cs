using Domain.Models;

namespace Domain.Repositories.Payment;

public interface IPaymentRepository
{
    public Task<Models.Payment> Create(long orderId, PaymentType paymentType);
    public Task SetStatus(long paymentId, PaymentStatus paid);
    Task<Models.Payment> Fetch(long paymentId);
}