using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class TravelerProfiles : Enumeration
{
    public static readonly TravelerProfiles Backpacker = new(1, nameof(Backpacker));
    public static readonly TravelerProfiles Tourist = new(2, nameof(Tourist));
    public static readonly TravelerProfiles Photographer = new(3, nameof(Photographer));

    private TravelerProfiles(int id, string name) : base(id, name)
    {
    }
}
