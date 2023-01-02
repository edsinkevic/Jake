using System.Security.Principal;
using Domain.Repositories.Product;

namespace Domain.UseCases.Product;

public class ListProductsUseCase
{
    private readonly IProductRepository _products;

    public ListProductsUseCase(IProductRepository products)
    {
        _products = products;
    }

    public async Task<List<Models.Product>> Execute()
    {
        return await _products.List();
    }
}