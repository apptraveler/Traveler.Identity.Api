using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Infra.Data.Context;

namespace Traveler.Identity.Api.Infra.Data.Repositories;

public class TravelerLocationRepository : Repository<TravelerLocation>, ITravelerLocationRepository
{
    public TravelerLocationRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<List<TravelerLocation>> GetAllByTravelerId(Guid travelerId)
    {
        return await DbSet
            .Where(travelerLocation => travelerLocation.TravelerId.Equals(travelerId))
            .ToListAsync();
    }
}
