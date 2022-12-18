using Domain.Repositories.Employee;

namespace Domain.UseCases.Employee;

public class ChangePrivilegesUseCase
{
    private readonly IEmployeeRepository _employees;

    public ChangePrivilegesUseCase(IEmployeeRepository employees)
    {
        _employees = employees;
    }

    public async Task<Models.Employee> Execute(ChangeEmployeePrivilegesDto employeeDto)
    {
        await _employees.RemovePrivileges(employeeDto);
        
        return await _employees.AddPrivileges(employeeDto);
    }
}