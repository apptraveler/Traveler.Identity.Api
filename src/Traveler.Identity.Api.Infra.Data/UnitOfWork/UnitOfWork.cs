using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.SeedWork;
using Traveler.Identity.Api.Infra.Data.Context;

namespace Traveler.Identity.Api.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UnitOfWork(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> CommitAsync()
    {
        return await _applicationDbContext.SaveEntitiesAsync();
    }

    public void Dispose()
    {
        _applicationDbContext.Dispose();
    }
}
