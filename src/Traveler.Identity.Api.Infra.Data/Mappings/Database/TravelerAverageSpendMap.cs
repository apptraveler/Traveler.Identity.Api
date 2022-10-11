using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate;
using Traveler.Identity.Api.Domain.SeedWork;

namespace Traveler.Identity.Api.Infra.Data.Mappings.Database;

public class TravelerAverageSpendMap : IEntityTypeConfiguration<TravelerAverageSpend>
{
    public void Configure(EntityTypeBuilder<TravelerAverageSpend> builder)
    {
        builder.ToTable("TravelerAverageSpend");

        builder.HasKey(travelerProfile => travelerProfile.Id);

        builder.Property(travelerProfile => travelerProfile.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name")
            .IsRequired();

        builder.HasData(Enumeration.GetAll<TravelerAverageSpend>());
    }
}
