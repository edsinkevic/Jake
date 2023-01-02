namespace Domain.Models;

public class Employee
{
    public long Id { get; set; }
    public Business? Business { get; set; }
    public List<Privilege> Privileges { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}