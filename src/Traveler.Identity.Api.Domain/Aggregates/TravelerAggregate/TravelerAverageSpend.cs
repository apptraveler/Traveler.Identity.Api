using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class TravelerAverageSpend : Enumeration
{
    public static readonly TravelerAverageSpend Low = new(1, "Baixo");
    public static readonly TravelerAverageSpend Medium = new(2, "Médio");
    public static readonly TravelerAverageSpend High = new(3, "Alto");

    public TravelerAverageSpend(int id, string name) : base(id, name)
    {
    }
}
