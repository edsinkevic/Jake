namespace Domain.Errors;

public class CustomerDoesNotExist : Exception
{
    public CustomerDoesNotExist(string message) : base(message)
    {
    }
}