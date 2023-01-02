using Domain.UseCases.Customer;

namespace Domain.Repositories.Customer;

public interface ICustomerRepository
{
    public Task<Models.Customer> Create(CreateCustomerDto customerDto);
    public Task<IEnumerable<Models.Customer>> List();
    public Task Update(UpdateCustomerDto customerDto);
    public Task Delete(long customerId);
    public Task<Models.Customer?> Find(long dtoCustomerId);
}