using MediatR;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Application.Validations;

namespace Traveler.Identity.Application.Commands
{
    public class LoginJourneyerCommand : Command, IRequest<LoginJourneyerResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginJourneyerCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            var isValidResult = new LoginJourneyerCommandValidation().Validate(this);
            return isValidResult.IsValid;
        }
    }
}