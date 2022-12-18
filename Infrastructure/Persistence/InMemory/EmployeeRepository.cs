using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Employee;
using Domain.UseCases.Employee;
using Infrastructure.Database;
using Infrastructure.Models;

namespace Infrastructure.Persistence.InMemory;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly InMemoryDbContext _context;

    public EmployeeRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> Create(CreateEmployeeDto employeeDto)
    {
        var employee = new Data.Employee
        {
            Address = employeeDto.Address,
            City = employeeDto.City,
            Email = employeeDto.Email,
            Fullname = employeeDto.Fullname,
            Id = employeeDto.Id,
            Password = employeeDto.Password,
            PhoneNumber = employeeDto.PhoneNumber,
            Privileges = new List<Privilege>(),
            Username = employeeDto.Username
        };
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee.ToDomain();
    }

    public async Task<Employee> RemovePrivileges(ChangeEmployeePrivilegesDto employeeDto)
    {
        var employee = await FindEmployee(employeeDto.EmployeeId);

        employee.Privileges.RemoveAll(privilege =>
            employeeDto.RemovePrivileges.Exists(privilegeToRemove => privilegeToRemove == privilege));

        _context.Attach(employee);

        await _context.SaveChangesAsync();

        return employee.ToDomain();
    }

    public async Task<Employee> AddPrivileges(ChangeEmployeePrivilegesDto employeeDto)
    {
        var employee = await FindEmployee(employeeDto.EmployeeId);

        employee.Privileges = employee.Privileges.Union(employeeDto.AddPrivileges).ToList();

        _context.Attach(employee);
        await _context.SaveChangesAsync();

        return employee.ToDomain();
    }

    private async Task<Data.Employee> FindEmployee(long id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
            throw new EmployeeDoesNotExist($"Employee {id} doesn't exist");

        return employee;
    }
}