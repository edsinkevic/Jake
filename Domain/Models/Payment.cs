namespace Domain.Models;

public class Payment
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public PaymentType PaymentType { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal Taxes { get; set; }
    public decimal Tips { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime Date { get; set; }

    public bool IsPaid() => Status == PaymentStatus.Paid;
}

public enum PaymentStatus
{
    Paid, Pending
}