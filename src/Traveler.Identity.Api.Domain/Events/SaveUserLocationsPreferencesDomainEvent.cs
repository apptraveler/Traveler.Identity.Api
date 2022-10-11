using System;
using System.Collections.Generic;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

namespace Traveler.Identity.Api.Domain.Events;

public class SaveUserLocationsPreferencesDomainEvent : Event
{
    public IReadOnlyCollection<TravelerLocationTags> Locations { get; }
    public Guid TravelerId { get; }

    public SaveUserLocationsPreferencesDomainEvent(Guid travelerId, IReadOnlyCollection<TravelerLocationTags> locations)
    {
        Locations = locations;
        TravelerId = travelerId;
    }
}
