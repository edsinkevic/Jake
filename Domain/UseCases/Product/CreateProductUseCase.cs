using Domain.Errors;
using Domain.Repositories.Business;
using Domain.Repositories.Product;

namespace Domain.UseCases.Product;

public class CreateProductUseCase
{
    private readonly IProductRepository _products;
    private readonly IBusinessRepository _businessRepository;

    public CreateProductUseCase(IProductRepository products, IBusinessRepository businessRepository)
    {
        _products = products;
        _businessRepository = businessRepository;
    }

    public async Task<Models.Product> Execute(CreateProductDto dto)
    {
        var business = await _businessRepository.Get(dto.BusinessId);
        if (business == null)
            throw new BusinessDoesNotExist("Business does not exist!");

        return await _products.Create(dto);
    }
}