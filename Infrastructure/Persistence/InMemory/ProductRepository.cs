using Domain.Models;
using Domain.Repositories.Product;
using Infrastructure.Database;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.InMemory;

public class ProductRepository : IProductRepository
{
    private readonly InMemoryDbContext _context;

    public ProductRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Create(CreateProductDto dto)
    {
        var product = new Data.Product
        {
            BusinessId = dto.BusinessId,
            Description = dto.Description,
            Enabled = true,
            Image = dto.Image,
            Name = dto.Name,
            Price = dto.Price, TaxRate = dto.TaxRate
        };

        await _context.AddAsync(product);
        await _context.SaveChangesAsync();

        return product.ToDomain();
    }

    public async Task<List<Product>> List()
    {
        var products = await _context.Products.ToListAsync();
        return products.Select(product => product.ToDomain()).ToList();
    }


    public async Task<bool> IdsExist(IEnumerable<long> dtoProductIds)
    {
        var products = dtoProductIds.Select(async id => await _context.Products.FindAsync(id));
        var completed = await Task.WhenAll(products);
        return completed.All(product => product != null);
    }
}