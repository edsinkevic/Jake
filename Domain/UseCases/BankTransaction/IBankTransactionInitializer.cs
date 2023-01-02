namespace Domain.UseCases.BankTransaction;

public interface IBankTransactionInitializer
{
    Task<string> Initialize(Models.Payment payment);
}