using System.Collections.Generic;
using Traveler.Identity.Api.Application.Dtos;

namespace Traveler.Identity.Api.Application.Queries;

public class GetTravelerProfilesQuery : Query<IEnumerable<TravelerProfilesResponse>>
{
    public override bool IsValid() => true;
}
