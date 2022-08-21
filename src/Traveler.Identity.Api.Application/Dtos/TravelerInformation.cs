using System;

namespace Traveler.Identity.Api.Application.Dtos;

public class TravelerInformation
{
    public string Email { get; }
    public string FullName { get; }
    public DateTime BirthDate { get; }

    public TravelerInformation(string email, string fullName, DateTime birthDate)
    {
        Email = email;
        FullName = fullName;
        BirthDate = birthDate;
    }
}
