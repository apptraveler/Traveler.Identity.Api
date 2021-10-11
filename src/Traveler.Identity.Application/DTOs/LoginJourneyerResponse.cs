namespace Traveler.Identity.Application.DTOs
{
    public class LoginJourneyerResponse
    {
        public string Token { get; set; }

        public LoginJourneyerResponse(string token)
        {
            Token = token;
        }
    }
}