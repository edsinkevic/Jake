using Domain.Errors;
using Domain.Repositories.Business;
using Domain.Repositories.BusinessLocation;

namespace Domain.UseCases.BusinessLocation;

public class CreateBusinessLocationUseCase
{
    private readonly IBusinessLocationRepository _locations;
    private readonly IBusinessRepository _businessRepository;

    public CreateBusinessLocationUseCase(IBusinessLocationRepository locations, IBusinessRepository businessRepository)
    {
        _locations = locations;
        _businessRepository = businessRepository;
    }

    public async Task<Models.BusinessLocation> Execute(CreateBusinessLocationDto dto)
    {
        var business = await _businessRepository.Get(dto.BusinessId);
        if (business == null)
            throw new BusinessDoesNotExist($"Business {dto.BusinessId} does not exist!");
        
        return await _locations.Create(dto);
    }
}