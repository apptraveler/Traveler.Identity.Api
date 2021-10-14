using FluentValidation;
using Traveler.Identity.Application.Commands;

namespace Traveler.Identity.Application.Validations
{
    public class RegisterJourneyerCommandValidation : AbstractValidator<RegisterJourneyerCommand>
    {
        public RegisterJourneyerCommandValidation()
        {
            ValidateEmail();
            ValidateUsername();
        }

        private void ValidateEmail()
        {
            RuleFor(command => command.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email não pode ser null ou vazio")
                .WithErrorCode("009")
                .EmailAddress()
                .WithMessage("Email inválido")
                .WithErrorCode("010");
        }

        private void ValidateUsername()
        {
            RuleFor(command => command.Username)
                .NotEmpty()
                .NotNull()
                .WithMessage("Username não pode ser null ou vazio")
                .WithErrorCode("011");
        }
    }
}