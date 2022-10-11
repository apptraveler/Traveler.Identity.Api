using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

public class TravelerLocationTags : Enumeration
{
    public static readonly TravelerLocationTags Mountains = new(1, nameof(Mountains));
    public static readonly TravelerLocationTags Beach = new(2, nameof(Beach));
    public static readonly TravelerLocationTags Waterfalls = new(3, nameof(Waterfalls));
    public static readonly TravelerLocationTags Trails = new(4, nameof(Trails));
    public static readonly TravelerLocationTags TouristSpots = new(5, nameof(TouristSpots));
    public static readonly TravelerLocationTags HistoricalPlaces = new(6, nameof(HistoricalPlaces));

    public TravelerLocationTags(int id, string name) : base(id, name)
    {
    }
}
