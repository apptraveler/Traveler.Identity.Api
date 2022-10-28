using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate;

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

        builder.Property(travelerProfile => travelerProfile.Description)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Description")
            .IsRequired();

        builder.HasData(GenerateData());
    }

    private static TravelerProfile[] GenerateData()
    {
        return new[]
        {
            new TravelerProfile("Mochileiro", "Para o perfil mochileiro o que importa é a jornada e as experiências adquiridas, o destino é apenas uma consequência."),
            new TravelerProfile("Turista", "Você gosta de aproveitar tudo que o destino têm a oferecer, pontos turísticos, culinária, museus, parques, arquitetura e todo o resto."),
            new TravelerProfile("Fotógrafo", "O perfil fotógrafo gosta de tirar fotos de tudo que vê pela frente, registrar os momentos é o que é importante, detalhes pra você são a chave."),
            new TravelerProfile("Econômico", "Economia é tudo! Você quer aproveitar ao máximo gastando o menos possível, custo benefício é o seu foco."),
            new TravelerProfile("Auto Conhecedor", "Profundo, aprimorar o auto-conhecimento por meio de novas culturas, ensinamentos e buscar a paz interior é o seu foco."),
            new TravelerProfile("Social", "Viajar para conhecer novas pessoas, curtir com os amigos, família, é o seu objetivo, o que importa é estar perto de pessoas interessantes.")
        };
    }
}
