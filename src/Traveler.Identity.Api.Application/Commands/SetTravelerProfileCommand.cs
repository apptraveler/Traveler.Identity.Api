using System;
using MediatR;
using Traveler.Identity.Api.Application.Validations;

namespace Traveler.Identity.Api.Application.Commands;

public class SetTravelerProfileCommand : Command<Unit>
{
    public Guid UserId { get; }
    public int ProfileId { get; }
    public int AverageSpendId { get; }
    public int[] LocationTagsIds { get; }

    public SetTravelerProfileCommand(Guid userId, int profileId, int averageSpendId, int[] locationTagsIds)
    {
        UserId = userId;
        ProfileId = profileId;
        AverageSpendId = averageSpendId;
        LocationTagsIds = locationTagsIds;
    }

    public override bool IsValid()
    {
        ValidationResult = new SetTravelerProfileCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
