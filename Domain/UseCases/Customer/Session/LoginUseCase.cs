using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Customer.Session;

namespace Domain.UseCases.Customer.Session;

public class LoginUseCase
{
    
    private readonly ICustomerSessionRepository _customerSessions;

    public LoginUseCase(ICustomerSessionRepository customerSessions)
    {
        _customerSessions = customerSessions;
    }
    
    public async Task<CustomerSession> Execute(LoginCredentials loginCredentials)
    {
        var customerSession = await _customerSessions.Create(loginCredentials);
        return customerSession;
    }
}