namespace Domain.Models;

public class Customer
{
    public long Id { get; set; }

    public long BusinessId { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
}