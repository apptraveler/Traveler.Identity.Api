using MediatR;
using Traveler.Identity.Application.DTOs;
using Traveler.Identity.Application.Validations;

namespace Traveler.Identity.Application.Commands
{
    public class JourneyerForgotPasswordCommand : Command, IRequest<JourneyerForgotPasswordResponse>
    {
        public string Email { get; set; }

        public JourneyerForgotPasswordCommand(string email)
        {
            Email = email;
        }

        public override bool IsValid()
        {
            var isValidResult = new JourneyerForgotPasswordCommandValidation().Validate(this);
            return isValidResult.IsValid;
        }
    }
}