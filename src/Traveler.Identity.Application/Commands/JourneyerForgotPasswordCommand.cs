using MediatR;
using Traveler.Identity.Application.DTOs;

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
            return true;
        }
    }
}