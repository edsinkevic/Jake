using Domain.Errors;
using Domain.Models;
using Domain.Repositories.Employee;
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
            Email = employeeDto.Email,
            Password = employeeDto.Password,
            Privileges = new List<Data.Privilege>(),
        };
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee.ToDomain();
    }

    public async Task<Employee> RemovePrivileges(ChangeEmployeePrivilegesDto employeeDto)
    {
        var employee = await FindEmployee(employeeDto.EmployeeId);

        var domainPrivileges = employee.DomainPrivileges();

        domainPrivileges.RemoveAll(privilege =>
            employeeDto.RemovePrivileges.Exists(privilegeToRemove => privilegeToRemove == privilege));

        employee.Privileges =
            DomainPrivilegesToData(employee.Id, domainPrivileges);

        _context.Attach(employee);

        await _context.SaveChangesAsync();

        return employee.ToDomain();
    }

    public async Task<Employee> AddPrivileges(ChangeEmployeePrivilegesDto employeeDto)
    {
        var employee = await FindEmployee(employeeDto.EmployeeId);

        var privileges = employee.DomainPrivileges().Union(employeeDto.AddPrivileges).ToList();
        employee.Privileges =
            DomainPrivilegesToData(employee.Id, privileges);

        _context.Attach(employee);
        await _context.SaveChangesAsync();

        return employee.ToDomain();
    }

    public async Task<bool> Exists(long dtoEmployeeId)
    {
        return await _context.Employees.FindAsync(dtoEmployeeId) != null;
    }

    private async Task<Data.Employee> FindEmployee(long id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
            throw new EmployeeDoesNotExist($"Employee {id} doesn't exist");

        return employee;
    }

    private static List<Data.Privilege> DomainPrivilegesToData(long employeeId, IEnumerable<Privilege> privileges) =>
        privileges.Select(x => new Data.Privilege { EmployeeId = employeeId, PrivilegeType = x }).ToList();
}