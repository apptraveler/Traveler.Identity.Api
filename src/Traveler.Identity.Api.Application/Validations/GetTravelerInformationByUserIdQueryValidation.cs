using FluentValidation;
using Traveler.Identity.Api.Application.Queries;

namespace Traveler.Identity.Api.Application.Validations;

public class GetTravelerInformationByIdQueryValidation : AbstractValidator<GetTravelerInformationByIdQuery>
{
    public GetTravelerInformationByIdQueryValidation()
    {
        ValidateTravelerId();
    }

    private void ValidateTravelerId()
    {
        RuleFor(c => c.TravelerId)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("88")
            .WithMessage("O id de viajante deve ser informado");
    }
}
