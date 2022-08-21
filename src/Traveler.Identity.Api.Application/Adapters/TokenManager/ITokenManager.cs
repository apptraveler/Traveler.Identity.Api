namespace Traveler.Identity.Api.Application.Adapters.TokenManager;

public interface ITokenManager
{
    string GetUserClaimFromToken(string claim, string token);
    string Generate(Domain.Aggregates.TravelerAggregate.Traveler traveler);
    bool Validate(string token);
}
