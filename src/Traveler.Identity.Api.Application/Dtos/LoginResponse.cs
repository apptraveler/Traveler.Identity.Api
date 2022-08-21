namespace Traveler.Identity.Api.Application.Dtos;

public class LoginResponse
{
    public string Token { get; }

    public LoginResponse(string token)
    {
        Token = token;
    }
}
