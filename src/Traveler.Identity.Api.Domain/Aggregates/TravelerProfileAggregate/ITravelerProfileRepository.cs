using System.Collections.Generic;
using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;

public interface ITravelerProfileRepository : IRepository<TravelerProfile>
{
    Task<ICollection<TravelerProfile>> GetAllAsync();
}
