using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;
using Traveler.Identity.Api.Infra.Data.Context;

namespace Traveler.Identity.Api.Infra.Data.Repositories;

public class TravelerProfileRepository : Repository<TravelerProfile>, ITravelerProfileRepository
{
    public TravelerProfileRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<ICollection<TravelerProfile>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }
}
