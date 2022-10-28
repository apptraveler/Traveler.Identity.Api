using System;
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

    public TravelerInformationResponse(string email, string fullName, TravelerProfile profile, TravelerAverageSpend averageSpend, TravelerLocationTags[] locationTags = default)
    {
        Email = email;
        FullName = fullName;
        Profile = profile is not null ? new TravelerProfileDto(profile.Id, profile.Name, profile.Description) : default;
        AverageSpend = averageSpend;
        LocationTags = locationTags;
    }
}

public class TravelerProfileDto
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }

    public TravelerProfileDto(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
