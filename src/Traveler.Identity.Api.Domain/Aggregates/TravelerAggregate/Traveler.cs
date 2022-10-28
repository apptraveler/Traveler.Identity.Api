using System;
using System.Collections.Generic;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;
using Traveler.Identity.Api.Domain.Events;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;

public class Traveler : Entity, IAggregateRoot
{
    public string Email { get; }
    public string FullName { get; }
    public string Password { get; }
    public byte[] Salt { get; }

    // public DateTime BirthDate { get; }

    private Guid? ProfileId { get; set; }
    private int? AverageSpendId { get; set; }

    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public virtual TravelerProfile Profile { get; private set; }
    public virtual TravelerAverageSpend AverageSpend { get; private set; }

    public Traveler(string email, string fullName, string password)
    {
        // BirthDate = birthDate;
        Email = email;
        FullName = fullName.ToUpperInvariant();
        (Password, Salt) = PasswordHasher.Hash(password);
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    protected Traveler()
    {
    }

    public bool CanLogin(string password)
    {
        return PasswordHasher.Check(Password, Salt, password);
    }

    public bool HasTravelProfile()
    {
        return Profile is not null;
    }

    public void SetTravelProfile(Guid profileId, TravelerAverageSpend averageSpend, IReadOnlyCollection<TravelerLocationTags> locationTags)
    {
        ProfileId = profileId;
        AverageSpend = averageSpend;

        AddDomainEvent(new SaveUserLocationsPreferencesDomainEvent(Id, locationTags));
    }
}
