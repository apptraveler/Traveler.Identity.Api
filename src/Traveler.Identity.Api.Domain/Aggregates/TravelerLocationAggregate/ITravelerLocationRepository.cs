using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

public interface ITravelerLocationRepository : IRepository<TravelerLocation>
{
    Task<List<TravelerLocation>> GetAllByTravelerId(Guid travelerId);
}
