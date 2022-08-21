using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Infra.Data.Context;

namespace Traveler.Identity.Api.Infra.Data.Repositories;

public class TravelerRepository : Repository<Domain.Aggregates.TravelerAggregate.Traveler>, ITravelerRepository
{
    public TravelerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }

    public async Task<Domain.Aggregates.TravelerAggregate.Traveler> GetByEmailAsync(string email)
    {
        return await DbSet.SingleOrDefaultAsync(t => t.Email.Equals(email));
    }

    public async Task<Domain.Aggregates.TravelerAggregate.Traveler> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }
}
