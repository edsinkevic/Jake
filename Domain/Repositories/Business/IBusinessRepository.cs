namespace Domain.Repositories.Business;

public interface IBusinessRepository
{
    public Task<Models.Business> Create(CreateBusinessDto businessDto);
    public Task<IEnumerable<Models.Business>> List();
}