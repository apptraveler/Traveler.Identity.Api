namespace Traveler.Identity.Api.Domain.SeedWork;

public interface IRepository<TEntity> where TEntity : IAggregateRoot
{
    void Add(TEntity obj);
}
