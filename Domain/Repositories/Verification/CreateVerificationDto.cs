namespace Domain.Repositories.Verification;

public class CreateVerificationDto
{
    public string VerificationToken { get; set; } = null!;
    public long CustomerId { get; set; }
}