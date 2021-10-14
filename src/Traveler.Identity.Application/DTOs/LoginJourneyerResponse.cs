namespace Traveler.Identity.Application.DTOs
{
    public class LoginJourneyerResponse
    {
        public string Token { get; }
        public bool IsFirstLogin { get; }

        public LoginJourneyerResponse(string token, bool isFirstLogin)
        {
            Token = token;
            IsFirstLogin = isFirstLogin;
        }
    }
}