using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate;

namespace Traveler.Identity.Api.Infra.Data.Mappings.Database;

public class TravelerLocationMap : IEntityTypeConfiguration<TravelerLocation>
{
    public void Configure(EntityTypeBuilder<TravelerLocation> builder)
    {
        builder.ToTable("TravelerLocation");

        builder.HasKey(travelerProfile => travelerProfile.Id);

        builder.HasOne<Domain.Aggregates.TravelerAggregate.Traveler>()
            .WithMany()
            .HasPrincipalKey(travelerLocation => travelerLocation.Id)
            .HasForeignKey(travelerLocation => travelerLocation.TravelerId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne<TravelerLocationTags>()
            .WithMany()
            .HasPrincipalKey(travelerLocation => travelerLocation.Id)
            .HasForeignKey(travelerLocation => travelerLocation.LocationId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
