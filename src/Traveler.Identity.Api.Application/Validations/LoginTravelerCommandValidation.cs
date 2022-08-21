using FluentValidation;
using Traveler.Identity.Api.Application.Commands;

namespace Traveler.Identity.Api.Application.Validations;

public class LoginTravelerCommandValidation : AbstractValidator<LoginTravelerCommand>
{
    public LoginTravelerCommandValidation()
    {
        ValidateEmail();
        ValidatePassword();
    }

    private void ValidateEmail()
    {
        RuleFor(c => c.Email)
            .EmailAddress()
            .WithErrorCode("88")
            .WithMessage("O email deve ser informado");
    }

    private void ValidatePassword()
    {
        RuleFor(c => c.Password)
            .NotEmpty()
            .NotNull()
            .WithErrorCode("88")
            .WithMessage("A senha deve ser informada");
    }
}
