using MediatR;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Validations;

namespace Traveler.Identity.Api.Application.Commands;

public class LoginTravelerCommand : Command<LoginResponse>
{
    public string Email { get; }
    public string Password { get; }

    public LoginTravelerCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public override bool IsValid()
    {
        ValidationResult = new LoginTravelerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}
