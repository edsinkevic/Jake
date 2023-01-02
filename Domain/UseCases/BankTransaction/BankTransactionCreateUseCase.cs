using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Payment;

namespace Domain.UseCases.BankTransaction;

public class BankTransactionCreateUseCase
{
    private readonly IPaymentRepository _payments;
    private readonly IBankTransactionRepository _bankTransactions;
    private readonly IBankTransactionInitializer _bankTransactionInitializer;

    public BankTransactionCreateUseCase(IPaymentRepository payments, IBankTransactionRepository bankTransactions, IBankTransactionInitializer bankTransactionInitializer)
    {
        _payments = payments;
        _bankTransactions = bankTransactions;
        _bankTransactionInitializer = bankTransactionInitializer;
    }

    public async Task<Models.BankTransaction> Execute(long paymentId)
    {
        var payment = await _payments.Fetch(paymentId);
        if (payment.IsPaid())
            throw new AlreadyPaid("Payment {paymentId} was already paid");
        var checkoutKey = await _bankTransactionInitializer.Initialize(payment);
        var bankTransaction = await _bankTransactions.CreateForPayment(checkoutKey, payment.Id);
        return bankTransaction;
    }
}