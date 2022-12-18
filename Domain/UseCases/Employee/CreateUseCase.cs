using Domain.Repositories.Employee;

namespace Domain.UseCases.Employee;

public class CreateUseCase
{
    private readonly IEmployeeRepository _employees;

    public CreateUseCase(IEmployeeRepository employees)
    {
        _employees = employees;
    }

    public async Task<Models.Employee> Execute(CreateEmployeeDto employeeDto)
    {
        return await _employees.Create(employeeDto);
    }

}