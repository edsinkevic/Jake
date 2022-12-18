namespace Domain.Models;

public class Business
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Customer> Customers { get; set; } = null!;
}