using Domain.Models;

namespace Domain.Repositories.Customer.Session;

public interface ICustomerSessionRepository
{
    public Task<CustomerSession?> FindValid(string sessionToken);
    public Task<CustomerSession> Create(LoginCredentials loginCredentials);
    public Task<CustomerSession?> Expire(string sessionToken);
}