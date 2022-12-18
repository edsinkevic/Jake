namespace Domain.Models;

public class Verification
{
    public long Id { get; set; }
    public bool Verified { get; set; }
    public long CustomerId { get; set; }
    public string VerificationToken { get; set; } = null!;
    public Customer? Customer { get; set; }
}