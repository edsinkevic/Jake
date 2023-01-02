namespace Domain.UseCases.BankTransaction;

public interface IBankTransactionRepository
{
    Task<Models.BankTransaction> CreateForPayment(string checkoutKey, long paymentId);
}