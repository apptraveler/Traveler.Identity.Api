using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class DestinationPreferences : Enumeration
{
    public static readonly DestinationPreferences International = new(1, nameof(International));
    public static readonly DestinationPreferences National = new(2, nameof(National));
    public static readonly DestinationPreferences Both = new(3, nameof(National));

    public DestinationPreferences(int id, string name) : base(id, name)
    {
    }
}
