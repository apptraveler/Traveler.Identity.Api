using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

namespace Traveler.Identity.Api.Application.Dtos;

public class TravelerInformation
{
    public string Email { get; }
    public string FullName { get; }
    public TravelerProfile Profile { get; }
    public TravelerAverageSpend AverageSpend { get; }
    public TravelerLocationTags[] LocationTags { get; }

    public TravelerInformation(string email, string fullName, TravelerProfile profile, TravelerAverageSpend averageSpend, TravelerLocationTags[] locationTags = default)
    {
        Email = email;
        FullName = fullName;
        Profile = profile;
        AverageSpend = averageSpend;
        LocationTags = locationTags;
    }
}
