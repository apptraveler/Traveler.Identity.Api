using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

public class TravelerLocationTags : Enumeration
{
    public static readonly TravelerLocationTags Mountains = new(1, "Montanhas");
    public static readonly TravelerLocationTags Beach = new(2, "Praias");
    public static readonly TravelerLocationTags Waterfalls = new(3, "Cachoeiras");
    public static readonly TravelerLocationTags Trails = new(4, "Trilhas");
    public static readonly TravelerLocationTags TouristSpots = new(5, "Pontos Turísticos");
    public static readonly TravelerLocationTags HistoricalPlaces = new(6, "Lugares Históricos");

    public TravelerLocationTags(int id, string name) : base(id, name)
    {
    }
}
