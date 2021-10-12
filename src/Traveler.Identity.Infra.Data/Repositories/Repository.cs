using Microsoft.EntityFrameworkCore;
using Traveler.Identity.Domain.SeedWork;
using Traveler.Identity.Infra.Data.Context;

namespace Traveler.Identity.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly ApplicationDbContext ApplicationDbContext;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
            DbSet = applicationDbContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            ApplicationDbContext.Add(obj);
        }
    }
}