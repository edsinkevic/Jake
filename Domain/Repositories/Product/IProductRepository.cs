namespace Domain.Repositories.Product;

public interface IProductRepository
{
    public Task<Models.Product> Create(CreateProductDto dto);
    public Task<List<Models.Product>> List();
    public Task<bool> IdsExist(IEnumerable<long> dtoProductIds);
}