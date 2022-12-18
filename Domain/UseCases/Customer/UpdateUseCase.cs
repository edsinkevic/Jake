using Domain.Repositories;
using Domain.Repositories.Customer;

namespace Domain.UseCases.Customer;

public class UpdateUseCase
{
    private readonly ICustomerRepository _customers;

    public UpdateUseCase(ICustomerRepository customers)
    {
        _customers = customers;
    }
    
    public async Task Execute(UpdateCustomerDto customerDto)
    {
        await _customers.Update(customerDto);
    }
    
}