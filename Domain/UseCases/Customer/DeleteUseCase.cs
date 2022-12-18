using Domain.Repositories;
using Domain.Repositories.Customer;

namespace Domain.UseCases.Customer;

public class DeleteUseCase
{
    private readonly ICustomerRepository _customers;

    public DeleteUseCase(ICustomerRepository customers)
    {
        _customers = customers;
    }
    
    public async Task Execute(long customerId)
    {
        await _customers.Delete(customerId);
    }
    
}