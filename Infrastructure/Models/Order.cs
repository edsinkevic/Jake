using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models;

namespace Infrastructure.Models;

public partial class Data
{
    public class Order
    {
        public long Id { get; set; }
        public long BusinessId { get; set; }
        [ForeignKey("BusinessId")] public Business? Business { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")] public Customer? Customer { get; set; }
        public long EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] public Employee? Employee { get; set; }
        public long LocationId { get; set; }
        [ForeignKey("LocationId")] public BusinessLocation? Location { get; set; }

        public long PaymentId { get; set; }
        [ForeignKey("PaymentId")] public Payment? Payment { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }

        public Domain.Models.Order ToDomain() => new()
        {
            Business = Business?.ToDomain(), Customer = Customer?.ToDomain(), Date = Date,
            Employee = Employee?.ToDomain(), Id = Id, Location = Location?.ToDomain(), Payment = Payment?.ToDomain(),
            Status = Status
        };
    }
}