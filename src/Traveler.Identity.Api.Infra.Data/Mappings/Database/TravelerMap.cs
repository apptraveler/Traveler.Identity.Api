using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Traveler.Identity.Api.Infra.Data.Mappings.Database;

public class TravelerMap : IEntityTypeConfiguration<Domain.Aggregates.TravelerAggregate.Traveler>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.TravelerAggregate.Traveler> builder)
    {
        builder.ToTable("Traveler");

        builder.HasKey(traveler => traveler.Id);

        builder.Property(traveler => traveler.Email)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Email")
            .IsRequired();

        builder.Property(traveler => traveler.Password)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Password")
            .IsRequired();

        builder.Property(traveler => traveler.Salt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Salt")
            .IsRequired();

        builder.Property(traveler => traveler.FullName)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("FullName")
            .IsRequired();

        // builder.Property(traveler => traveler.BirthDate)
        //     .UsePropertyAccessMode(PropertyAccessMode.Field)
        //     .HasColumnName("BirthDate")
        //     .IsRequired();

        builder.Property(traveler => traveler.CreatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(traveler => traveler.UpdatedAt)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("UpdatedAt")
            .IsRequired();
    }
}
