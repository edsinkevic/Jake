namespace Domain.Errors;

public class VerificationDoesNotExist : Exception
{
    public VerificationDoesNotExist(string message) : base(message)
    {
    }
}