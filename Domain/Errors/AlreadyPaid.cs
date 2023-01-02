namespace Domain.Errors;

public class AlreadyPaid : DomainError
{
    public AlreadyPaid(string message) : base(message)
    {
    }
}