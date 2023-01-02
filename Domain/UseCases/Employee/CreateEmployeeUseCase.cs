using Domain.Errors;
using Domain.Repositories.Business;
using Domain.Repositories.Employee;

namespace Domain.UseCases.Employee;

public class CreateEmployeeUseCase
{
    private readonly IEmployeeRepository _employees;
    private readonly IBusinessRepository _businesses;

    public CreateEmployeeUseCase(IEmployeeRepository employees, IBusinessRepository businesses)
    {
        _employees = employees;
        _businesses = businesses;
    }

    public async Task<Models.Employee> Execute(CreateEmployeeDto employeeDto)
    {
        var business = await _businesses.Get(employeeDto.BusinessId);
        if (business == null)
            throw new BusinessDoesNotExist($"Business {employeeDto.BusinessId} doesn't exist");

        return await _employees.Create(employeeDto);
    }
}