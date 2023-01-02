using Domain.Models;

namespace Infrastructure.Models;

public partial class Data
{
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

        public Domain.Models.Payment ToDomain() => new()
        {
            Date = Date, Id = Id, OrderId = OrderId, PaymentType = PaymentType, Status = Status, Taxes = Taxes,
            Tips = Tips, TotalAmount = TotalAmount
        };
    }
}