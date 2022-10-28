using System.Linq;
using FluentValidation;
using Traveler.Identity.Api.Application.Commands;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
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
            .NotEmpty()
            .NotNull()
            .WithMessage("Informe o ProfileId")
            .WithErrorCode("88");
    }

    private void ValidateAverageSpendId()
    {
        RuleFor(comm => comm.AverageSpendId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .WithMessage("Informe o ProfileId")
            .WithErrorCode("88")
            .Must(averageSpendId => Enumeration.FromId<TravelerAverageSpend>(averageSpendId) is not null)
            .WithMessage($"Valores válidos: {string.Join(", ", Enumeration.GetAll<TravelerAverageSpend>())}")
            .WithErrorCode("88");
    }

    private void ValidateLocationTagsIds()
    {
        RuleFor(comm => comm.LocationTagsIds)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .NotNull()
            .WithMessage("Informe o ProfileId")
            .WithErrorCode("88")
            .Must(locationTagsIds => locationTagsIds.All(id => Enumeration.FromId<TravelerLocationTags>(id) is not null))
            .WithMessage($"Valores válidos: {string.Join(", ", Enumeration.GetAll<TravelerLocationTags>())}")
            .WithErrorCode("88");
    }
}
