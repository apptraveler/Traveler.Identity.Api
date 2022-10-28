using System;

namespace Traveler.Identity.Api.Application.Dtos;

public class TravelerProfilesResponse
{
    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }

    public TravelerProfilesResponse(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}
