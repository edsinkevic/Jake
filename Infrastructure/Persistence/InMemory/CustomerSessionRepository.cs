using Domain.Errors;
using Domain.Models;
using Domain.Repositories;
using Domain.Repositories.Customer.Session;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.InMemory;

public class CustomerSessionRepository : ICustomerSessionRepository
{
    private readonly InMemoryDbContext _context;

    public CustomerSessionRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<CustomerSession?> FindValid(string sessionToken)
    {
        var sessions = await _context.CustomerSessions.Where(x => x.SessionToken == sessionToken).ToListAsync();
        if (sessions.Count == 0)
            return null;
        var session = sessions.First().ToDomain();

        return session.Expired(DateTime.Now) ? null : session;
    }

    public async Task<CustomerSession> Create(LoginCredentials loginCredentials)
    {
        var customers = await _context.Customers.Where(x => x.Email == loginCredentials.Email).ToListAsync();
        if (!customers.Any())
            throw new CustomerDoesNotExist($"Customer with email {loginCredentials.Email} does not exist");
        var customer = customers.First();
        var session = new Data.CustomerSession
            { CustomerId = customer.Id, Expiry = DateTime.Now.AddHours(1), SessionToken = GenerateSessionToken() };

        await _context.CustomerSessions.AddAsync(session);
        await _context.SaveChangesAsync();
        return session.ToDomain();
    }

    public async Task<CustomerSession?> Expire(string sessionToken)
    {
        var sessions = await _context.CustomerSessions.Where(x => x.SessionToken == sessionToken).ToListAsync();
        if (sessions.Count == 0)
            return null;
        var session = sessions.First();
        session.Expire();
        _context.Attach(session);
        await _context.SaveChangesAsync();
        return session.ToDomain();
    }

    private static string GenerateSessionToken()
    {
        return Guid.NewGuid().ToString();
    }
}