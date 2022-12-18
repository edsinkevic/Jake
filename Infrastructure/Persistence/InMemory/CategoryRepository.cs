using Domain.Models;
using Domain.Repositories.Category;
using Infrastructure.Database;
using Infrastructure.Models;

namespace Infrastructure.Persistence.InMemory;

public class CategoryRepository : ICategoryRepository
{
    private readonly InMemoryDbContext _context;

    public CategoryRepository(InMemoryDbContext context)
    {
        _context = context;
    }
    public async Task<Category> Create(CreateCategoryDto dto)
    {
        var category = new Data.Category
        {
            Name = dto.Name, ParentCategoryId = dto.ParentCategoryId, BusinessId = dto.BusinessId
        };
        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return category.ToDomain();
    }
}