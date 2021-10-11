namespace Traveler.Identity.Application.DTOs
{
    public class RegisterJourneyerResponse
    {
        public string Token { get; }

        public RegisterJourneyerResponse(string token)
        {
            Token = token;
        }
    }
}