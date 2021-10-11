using MediatR;
using Traveler.Identity.Application.DTOs;

namespace Traveler.Identity.Application.Commands
{
    public class LoginJourneyerCommand : Command, IRequest<LoginJourneyerResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }

        public LoginJourneyerCommand(string usernameOrEmail, string password)
        {
            UsernameOrEmail = usernameOrEmail;
            Password = password;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}