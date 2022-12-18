using Domain.Models;

namespace Domain.Repositories.Employee;

public class ChangeEmployeePrivilegesDto
{
    public long EmployeeId { get; set; }
    public List<Privilege> RemovePrivileges { get; set; } = null!;
    public List<Privilege> AddPrivileges { get; set; } = null!;
}