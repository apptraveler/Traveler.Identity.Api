using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Infra.Data.Mappings.Database;

public class TravelerProfileMap : IEntityTypeConfiguration<TravelerProfile>
{
    public void Configure(EntityTypeBuilder<TravelerProfile> builder)
    {
        builder.ToTable("TravelerProfile");

        builder.HasKey(travelerProfile => travelerProfile.Id);

        builder.Property(travelerProfile => travelerProfile.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name")
            .IsRequired();

        builder.HasData(Enumeration.GetAll<TravelerProfile>());
    }
}
