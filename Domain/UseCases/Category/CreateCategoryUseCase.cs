using Domain.Repositories.Category;

namespace Domain.UseCases.Category;

public class CreateCategoryUseCase
{
    private readonly ICategoryRepository _categories;

    public CreateCategoryUseCase(ICategoryRepository categories)
    {
        _categories = categories;
    }

    public async Task<Models.Category> Execute(CreateCategoryDto dto)
    {
        return await _categories.Create(dto);
    }
}