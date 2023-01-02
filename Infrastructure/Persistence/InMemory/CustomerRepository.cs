using Domain.Errors;
using Domain.Repositories;
using Domain.Repositories.Customer;
using Domain.UseCases.Customer;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Customer = Domain.Models.Customer;

namespace Infrastructure.Persistence.InMemory;

public class CustomerRepository : ICustomerRepository
{
    private readonly InMemoryDbContext _context;

    public CustomerRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> Create(CreateCustomerDto customerDto)
    {
        var customer = new Data.Customer
        {
            Address = customerDto.Address,
            BusinessId = customerDto.BusinessId,
            Email = customerDto.Email,
            Password = customerDto.Password,
            PhoneNumber = customerDto.PhoneNumber,
            Username = customerDto.Username
        };

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return customer.ToDomain();
    }

    public async Task<IEnumerable<Customer>> List()
    {
        return await _context.Customers.Select(x => x.ToDomain()).ToListAsync();
    }

    public async Task Update(UpdateCustomerDto customerDto)
    {
        var customer = await _context.Customers.FindAsync(customerDto.CustomerId);

        if (customer == null)
            throw new CustomerDoesNotExist($"Customer of id {customerDto.CustomerId} doesn't exist");

        if (customerDto.Email != null)
            customer.Email = customerDto.Email;
        
        if (customerDto.Address != null)
            customer.Address = customerDto.Address;
        
        if (customerDto.PhoneNumber != null)
            customer.PhoneNumber = customerDto.PhoneNumber;
        
        if (customerDto.Username != null)
            customer.Username = customerDto.Username;

        _context.Attach(customer);
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(long customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null)
            throw new CustomerDoesNotExist($"Customer of id {customerId} doesn't exist");
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer?> Find(long dtoCustomerId)
    {
        var customer = await _context.Customers.FindAsync(dtoCustomerId);
        return customer?.ToDomain();
    }
}