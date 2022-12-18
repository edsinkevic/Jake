using Domain.Repositories;
using Domain.Repositories.Business;

namespace Domain.UseCases.Business;

public class CreateUseCase
{
    private readonly IBusinessRepository _businesses;

    public CreateUseCase(IBusinessRepository businesses)
    {
        _businesses = businesses;
    }

    public async Task<Models.Business> Execute(CreateBusinessDto businessDto) =>
        await _businesses.Create(businessDto);
}