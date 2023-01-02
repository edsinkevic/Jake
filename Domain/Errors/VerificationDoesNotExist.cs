namespace Domain.Errors;

public class VerificationDoesNotExist : DomainError
{
    public VerificationDoesNotExist(string message) : base(message)
    {
    }
}