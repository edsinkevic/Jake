namespace Domain.Errors;

public class CustomerDoesNotExist : DomainError
{
    public CustomerDoesNotExist(string message) : base(message)
    {
    }
}