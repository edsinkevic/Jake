namespace Domain.Models;

public class Customer
{
    public long Id { get; set; }
    public long BusinessId { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string Email { get; set; } = null!;
}