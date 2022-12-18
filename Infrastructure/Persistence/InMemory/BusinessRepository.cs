using Domain.Models;
using Domain.Repositories.Business;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.InMemory;

public class BusinessRepository : IBusinessRepository
{
    private readonly InMemoryDbContext _context;

    public BusinessRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Business> Create(CreateBusinessDto businessDto)
    {
        var business = new Data.Business { Name = businessDto.Name };
        await _context.Businesses.AddAsync(business);
        await _context.SaveChangesAsync();
        return business.ToDomain();
    }

    public async Task<IEnumerable<Business>> List()
    {
        var businesses = await _context.Businesses.Select(x => x.ToDomain()).ToListAsync();
        return businesses;
    }
}