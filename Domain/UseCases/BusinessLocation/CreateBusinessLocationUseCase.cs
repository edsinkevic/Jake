using Domain.Repositories.BusinessLocation;

namespace Domain.UseCases.BusinessLocation;

public class CreateBusinessLocationUseCase
{
    private readonly IBusinessLocationRepository _locations;

    public CreateBusinessLocationUseCase(IBusinessLocationRepository locations)
    {
        _locations = locations;
    }

    public async Task<Models.BusinessLocation> Execute(CreateBusinessLocationDto dto)
    {
        return await _locations.Create(dto);
    }
}