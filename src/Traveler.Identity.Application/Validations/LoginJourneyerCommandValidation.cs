using FluentValidation;
using Traveler.Identity.Application.Commands;

namespace Traveler.Identity.Application.Validations
{
    public class LoginJourneyerCommandValidation : AbstractValidator<LoginJourneyerCommand>
    {
        public LoginJourneyerCommandValidation()
        {
            ValidateEmail();
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
    }
}