using Domain.Repositories.Payment;

namespace Domain.UseCases.Payment;

public class CreatePaymentUseCase
{
    private readonly IPaymentRepository _payments;

    public CreatePaymentUseCase(IPaymentRepository payments)
    {
        _payments = payments;
    }

    public async Task<Models.Payment> Execute(CreatePaymentDto dto)
    {
        return await _payments.Create(dto.OrderId, dto.PaymentType);
    }
}