using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Infra.Data.Context;
using Traveler.Identity.Domain.Aggregates.JourneyerAggregate;

namespace Traveler.Identity.Infra.Data.Repositories.JourneyerRepository
{
    public class JourneyerRepository : Repository<Journeyer>, IJourneyerRepository
    {
        public JourneyerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<Journeyer> GetByEmailOrUsernameAsync(string emailOrUsername)
        {
            return await DbSet.FirstOrDefaultAsync(journeyer => journeyer.Email.Equals(emailOrUsername) || journeyer.Username.Equals(emailOrUsername));
        }
    }
}