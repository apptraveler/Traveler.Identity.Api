namespace Traveler.Identity.Api.Dtos.Request;

public class SetTravelerProfileRequest
{
    public string ProfileId { get; }
    public string AverageSpendId { get; }
    public string[] LocationTagsIds { get; }

    public SetTravelerProfileRequest(string profileId, string averageSpendId, string[] locationTagsIds)
    {
        ProfileId = profileId;
        AverageSpendId = averageSpendId;
        LocationTagsIds = locationTagsIds;
    }
}
