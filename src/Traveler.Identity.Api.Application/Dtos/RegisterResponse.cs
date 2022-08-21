namespace Traveler.Identity.Api.Application.Dtos;

public class RegisterResponse
{
    public string Token { get; }

    public RegisterResponse(string token)
    {
        Token = token;
    }
}
