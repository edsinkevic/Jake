using Domain.Models;
using Domain.Repositories.Payment;
using Infrastructure.Database;
using Infrastructure.Models;


public class PaymentRepository : IPaymentRepository
{
    private readonly InMemoryDbContext _context;

    public PaymentRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> Create(long orderId, PaymentType paymentType)
    {
        var payment = new Data.Payment
            { Date = DateTime.Now, OrderId = orderId, PaymentType = paymentType, Status = PaymentStatus.Pending };

        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        return payment.ToDomain();
    }

    public async Task SetStatus(long paymentId, PaymentStatus paid)
    {
        var payment = await _context.Payments.FindAsync(paymentId);
        if (payment == null)
            return;

        payment.Status = PaymentStatus.Paid;
        _context.Attach(payment);
        await _context.SaveChangesAsync();
    }

    public Task<Payment> Fetch(long paymentId)
    {
        throw new NotImplementedException();
    }
}