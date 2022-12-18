using Domain.Repositories.Product;

namespace Domain.UseCases.Product;

public class CreateProductUseCase
{
    private readonly IProductRepository _products;

    public CreateProductUseCase(IProductRepository products)
    {
        _products = products;
    }

    public async Task<Models.Product> Execute(CreateProductDto dto)
    {
        return await _products.Create(dto);
    }
}