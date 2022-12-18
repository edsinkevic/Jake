namespace Domain.Repositories.BusinessLocation;

public interface IBusinessLocationRepository
{
    public Task<Models.BusinessLocation> Create(CreateBusinessLocationDto dto);
}