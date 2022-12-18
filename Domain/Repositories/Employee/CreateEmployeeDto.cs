namespace Domain.Repositories.Employee;

public class CreateEmployeeDto
{
    public long Id { get; set; }
    public long BusinessId { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
}