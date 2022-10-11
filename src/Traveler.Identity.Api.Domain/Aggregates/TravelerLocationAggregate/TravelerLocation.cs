using System;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

public class TravelerLocation : Entity, IAggregateRoot
{
    public Guid TravelerId { get; }
    public int LocationId { get; }

    public TravelerLocation(Guid travelerId, int locationId)
    {
        TravelerId = travelerId;
        LocationId = locationId;
    }
}
