namespace Domain.Errors;

public class BusinessDoesNotExist : DomainError
{
    public BusinessDoesNotExist(string message) : base(message)
    {
    }
}