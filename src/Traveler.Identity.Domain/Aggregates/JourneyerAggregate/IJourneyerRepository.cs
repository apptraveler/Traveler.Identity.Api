using System.Threading.Tasks;
using Traveler.Identity.Domain.SeedWork;

namespace Traveler.Identity.Domain.Aggregates.JourneyerAggregate
{
    public interface IJourneyerRepository : IRepository<Journeyer>
    {
        Task<Journeyer> GetByEmailOrUsernameAsync(string emailOrUsername);
    }
}