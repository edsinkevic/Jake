using Domain.Repositories;
using Domain.Repositories.Customer;

namespace Domain.UseCases.Customer;

public class ListUseCase
{
    private readonly ICustomerRepository _customers;

    public ListUseCase(ICustomerRepository customers)
    {
        _customers = customers;
    }

    public async Task<IEnumerable<Models.Customer>> Execute()
    {
        return await _customers.List();
    }
}