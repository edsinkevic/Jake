using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Customer.Session;

namespace Domain.UseCases.Customer.Session;

public class LogoutUseCase
{
    private readonly ICustomerSessionRepository _customerSessions;

    public LogoutUseCase(ICustomerSessionRepository customerSessions)
    {
        _customerSessions = customerSessions;
    }

    public async Task<CustomerSession?> Execute(string sessionToken)
    {
        var customerSession = await _customerSessions.Expire(sessionToken);
        return customerSession;
    }
}