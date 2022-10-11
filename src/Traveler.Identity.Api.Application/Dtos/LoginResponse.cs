namespace Traveler.Identity.Api.Application.Dtos;

public class LoginResponse
{
    public string Token { get; }
    public bool TravelProfileCreated { get; }

    public LoginResponse(string token, bool travelProfileCreated)
    {
        Token = token;
        TravelProfileCreated = travelProfileCreated;
    }
}
