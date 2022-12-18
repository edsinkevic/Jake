using Domain.Models;
using Domain.Repositories.BusinessLocation;
using Infrastructure.Database;
using Infrastructure.Models;

namespace Infrastructure.Persistence.InMemory;

class BusinessLocationRepository : IBusinessLocationRepository
{
    private readonly InMemoryDbContext _context;

    public BusinessLocationRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<BusinessLocation> Create(CreateBusinessLocationDto dto)
    {
        var location = new Data.BusinessLocation
        {
            City = dto.City, Id = dto.BusinessId, Name = dto.Name, PhoneNumber = dto.PhoneNumber, Street = dto.Street,
            ZipCode = dto.ZipCode
        };
        await _context.BusinessLocations.AddAsync(location);

        await _context.SaveChangesAsync();

        return location.ToDomain();
    }
}