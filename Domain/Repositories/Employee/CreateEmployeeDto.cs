namespace Domain.Repositories.Employee;

public class CreateEmployeeDto
{
    public long BusinessId { get; set; }
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}