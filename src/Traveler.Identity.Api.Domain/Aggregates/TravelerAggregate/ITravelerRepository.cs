using System;
using System.Threading.Tasks;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public interface ITravelerRepository : IRepository<Traveler>
{
    public Task<Traveler> GetByEmailAsync(string email);
    public Task<Traveler> GetByIdAsync(Guid id);
}
