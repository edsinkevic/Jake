using Domain.Repositories;
using Domain.Repositories.Business;

namespace Domain.UseCases.Business;

public class ListUseCase
{
    private readonly IBusinessRepository _businesses;

    public ListUseCase(IBusinessRepository businesses)
    {
        _businesses = businesses;
    }

    public async Task<IEnumerable<Models.Business>> Execute()
    {
        return await _businesses.List();
    }
}