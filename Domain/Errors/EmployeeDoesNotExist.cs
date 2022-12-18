namespace Domain.Errors;

public class EmployeeDoesNotExist : Exception
{
    public EmployeeDoesNotExist(string message) : base(message)
    {
    }
}