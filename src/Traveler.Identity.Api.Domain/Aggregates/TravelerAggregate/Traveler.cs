using System;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class Traveler : Entity, IAggregateRoot
{
    public string Email { get; }
    public string FullName { get; }
    public string Password { get; }
    public byte[] Salt { get; }
    public TravelerProfiles Preferences { get; }
    public DateTime BirthDate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public Traveler(string email, string fullName, string password, DateTime birthDate)
    {
        BirthDate = birthDate;
        Email = email;
        FullName = fullName.ToUpperInvariant();
        (Password, Salt) = PasswordHasher.Hash(password);
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    protected Traveler() {}

    public bool CanLogin(string password)
    {
        return PasswordHasher.Check(Password, Salt, password);
    }
}
