using System;
using Traveler.Identity.Api.Application.Dtos;
using Traveler.Identity.Api.Application.Validations;

namespace Traveler.Identity.Api.Application.Commands;

public class RegisterTravelerCommand : Command<RegisterResponse>
{
    public string Email { get; }
    public string FullName { get; }
    public string Password { get; }
    public string BirthDate { get; }

    public RegisterTravelerCommand(string email, string fullName, string password, string birthDate)
    {
        Email = email;
        FullName = fullName;
        Password = password;
        BirthDate = birthDate;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterTravelerCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }

    public DateTime GetFormattedDate()
    {
        return DateTime.Parse(BirthDate);
    }
}
