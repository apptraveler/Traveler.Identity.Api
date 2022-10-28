using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class TravelerProfile : Enumeration
{
    public static readonly TravelerProfile Backpacker = new(1, nameof(Backpacker));
    public static readonly TravelerProfile Tourist = new(2, nameof(Tourist));
    public static readonly TravelerProfile Photographer = new(3, nameof(Photographer));
    public static readonly TravelerProfile Economic = new(4, nameof(Economic));
    public static readonly TravelerProfile PersonalGrowth = new(5, nameof(PersonalGrowth));
    public static readonly TravelerProfile Social = new(6, nameof(Social));

    private TravelerProfile(int id, string name) : base(id, name)
    {
    }
}
