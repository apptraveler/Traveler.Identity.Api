using System.Security.Claims;
using System.Collections.Generic;
using Traveler.Identity.Domain.Aggregates.JourneyerAggregate;

namespace Traveler.Identity.Application.Adapters.Authorization
{
    public interface IAuthorizationService
    {
        IEnumerable<Claim> GetTokenClaims(string token);
        bool ValidateToken(string token);
        string GenerateToken(Journeyer journeyer);
    }
}