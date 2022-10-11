using FluentValidation;
using Traveler.Identity.Api.Application.Commands;

namespace Traveler.Identity.Api.Application.Validations;

public class RegisterTravelerCommandValidation : AbstractValidator<RegisterTravelerCommand>
{
    public RegisterTravelerCommandValidation()
    {
        ValidateEmail();
        ValidatePassword();
        ValidateFullName();
        // ValidateBirthDate();
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

    private void ValidateFullName()
    {
        RuleFor(c => c.FullName)
            .NotNull()
            .NotEmpty()
            .Must(fullname => fullname.Split(" ").Length > 1)
            .WithErrorCode("88")
            .WithMessage("O nome completo deve ser informado");
    }

    // private void ValidateBirthDate()
    // {
    //     RuleFor(c => c.GetFormattedDate())
    //         .Must(birthDate => DateTime.UtcNow.CompareTo(birthDate) > 0)
    //         .WithErrorCode("88")
    //         .WithMessage("Informe uma data de nascimento válida")
    //         .OverridePropertyName(c => c.BirthDate);
    // }
}
