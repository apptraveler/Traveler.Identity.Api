using System.Linq;
using FluentValidation;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Application.Validations;

public class SetTravelerProfileCommandValidation : AbstractValidator<SetTravelerProfileCommand>
{
    public SetTravelerProfileCommandValidation()
    {
        ValidateProfileId();
        ValidateAverageSpendId();
        ValidateLocationTagsIds();
    }

    private void ValidateProfileId()
    {
        RuleFor(comm => comm.ProfileId)
            .Must(profileId => Enumeration.FromId<TravelerProfile>(profileId) is not null);
    }

    private void ValidateAverageSpendId()
    {
        RuleFor(comm => comm.AverageSpendId)
            .Must(averageSpendId => Enumeration.FromId<TravelerAverageSpend>(averageSpendId) is not null);
    }

    private void ValidateLocationTagsIds()
    {
        RuleFor(comm => comm.LocationTagsIds)
            .Must(locationTagsIds => locationTagsIds.All(id => Enumeration.FromId<TravelerProfile>(id) is not null));
    }
}
