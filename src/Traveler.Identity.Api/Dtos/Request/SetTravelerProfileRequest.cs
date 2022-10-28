using System;

namespace Traveler.Identity.Api.Dtos.Request;

public class SetTravelerProfileRequest
{
    public Guid ProfileId { get; }
    public string AverageSpendId { get; }
    public string[] LocationTagsIds { get; }

    public SetTravelerProfileRequest(Guid profileId, string averageSpendId, string[] locationTagsIds)
    {
        ProfileId = profileId;
        AverageSpendId = averageSpendId;
        LocationTagsIds = locationTagsIds;
    }
}
