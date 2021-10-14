using MediatR;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Application.Validations;

namespace Traveler.Identity.Application.Commands
{
    public class RegisterJourneyerCommand : Command, IRequest<RegisterJourneyerResponse>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterJourneyerCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public override bool IsValid()
        {
            var isValidResult = new RegisterJourneyerCommandValidation().Validate(this);
            return isValidResult.IsValid;
        }
    }
}