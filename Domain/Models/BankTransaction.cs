namespace Domain.Models;

public class BankTransaction
{
    public long Id { get; set; }
    public string CheckoutKey { get; set; } = null!;
    public BankTransactionStatus Status { get; set; }
}
public enum BankTransactionStatus
{
    Pending, Done
}