using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;

namespace Traveler.Identity.Api.Application.Dtos;

public class TravelerInformationResponse
{
    public string Email { get; }
    public string FullName { get; }
    public TravelerProfileDto Profile { get; }
    public TravelerAverageSpend AverageSpend { get; }
    public TravelerLocationTags[] LocationTags { get; }

    public TravelerInformationResponse(string email, string fullName, string profileName, string profileDescription, TravelerAverageSpend averageSpend, TravelerLocationTags[] locationTags = default)
    {
        Email = email;
        FullName = fullName;
        Profile = new TravelerProfileDto(profileName, profileDescription);
        AverageSpend = averageSpend;
        LocationTags = locationTags;
    }
}

public class TravelerProfileDto
{
    public string Name { get; }
    public string Description { get; }

    public TravelerProfileDto(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
