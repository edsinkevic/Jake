using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace Domain.Models;

public class Order
{
    public long Id { get; set; }
    public Business? Business { get; set; }
    public Customer? Customer { get; set; }
    public Employee? Employee { get; set; }
    public BusinessLocation? Location { get; set; }
    public Payment? Payment { get; set; }
    public DateTime Date { get; set; }
    public OrderStatus Status { get; set; }
}
public enum OrderStatus
{
    Pending, InProgress, Done
}