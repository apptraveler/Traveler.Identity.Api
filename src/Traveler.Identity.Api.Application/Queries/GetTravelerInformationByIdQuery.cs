using System;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Validations;

namespace Traveler.Identity.Api.Application.Queries;

public class GetTravelerInformationByIdQuery : Query<TravelerInformationResponse>
{
    public Guid TravelerId { get; }

    public GetTravelerInformationByIdQuery(Guid travelerId)
    {
        TravelerId = travelerId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetTravelerInformationByIdQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
