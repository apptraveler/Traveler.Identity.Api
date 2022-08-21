using System.Threading.Tasks;

namespace Traveler.Identity.Api.Domain.SeedWork;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
