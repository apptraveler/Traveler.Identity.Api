using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traveler.Identity.Domain.Aggregates.JourneyerAggregate;

namespace Traveler.Identity.Infra.Data.Mappings.Database
{
    public class JourneyerMap : IEntityTypeConfiguration<Journeyer>
    {
        public void Configure(EntityTypeBuilder<Journeyer> builder)
        {
            builder.ToTable("journeyer");
            builder.HasKey(journeyer => journeyer.Id);
            
            builder.Property(journeyer => journeyer.Id)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(journeyer => journeyer.Email)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(journeyer => journeyer.Username)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("journeyername")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(journeyer => journeyer.Password)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("password")
                .IsRequired();
        }
    }
}