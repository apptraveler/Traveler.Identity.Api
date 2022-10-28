using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;

public class TravelerProfile : Entity, IAggregateRoot
{
    public string Name { get; }
    public string Description { get; }

    public TravelerProfile(string name, string description)
    {
        SetId();
        Name = name;
        Description = description;
    }

    private TravelerProfile()
    {
    }
}
