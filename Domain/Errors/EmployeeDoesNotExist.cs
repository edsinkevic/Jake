namespace Domain.Errors;

public class EmployeeDoesNotExist : DomainError
{
    public EmployeeDoesNotExist(string message) : base(message)
    {
    }
}