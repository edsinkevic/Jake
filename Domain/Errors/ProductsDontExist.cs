namespace Domain.Errors;

public class ProductsDontExist : DomainError
{
    public ProductsDontExist(string message) : base(message)
    {
    }
}