namespace Domain.Repositories.Category;

public interface ICategoryRepository
{
    public Task<Models.Category> Create(CreateCategoryDto dto);
}