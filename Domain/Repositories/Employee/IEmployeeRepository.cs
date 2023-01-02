using Domain.UseCases.Employee;

namespace Domain.Repositories.Employee;

public interface IEmployeeRepository
{
    public Task<Models.Employee> Create(CreateEmployeeDto employeeDto);
    public Task<Models.Employee> RemovePrivileges(ChangeEmployeePrivilegesDto employeeDto);
    public Task<Models.Employee> AddPrivileges(ChangeEmployeePrivilegesDto employeeDto);
    Task<bool> Exists(long dtoEmployeeId);
}