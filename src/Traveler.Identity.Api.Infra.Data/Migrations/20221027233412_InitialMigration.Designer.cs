﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Traveler.Identity.Api.Infra.Data.Context;

#nullable disable

namespace Traveler.Identity.Api.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221027233412_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.Traveler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int?>("AverageSpendId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AverageSpendId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("FullName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Password");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("TEXT")
                        .HasColumnName("ProfileId");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("BLOB")
                        .HasColumnName("Salt");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AverageSpendId")
                        .IsUnique();

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Traveler", (string)null);
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.TravelerAverageSpend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("TravelerAverageSpend", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Baixo"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Médio"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Alto"
                        });
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate.TravelerLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TravelerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TravelerId");

                    b.ToTable("TravelerLocation", (string)null);
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate.TravelerLocationTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("TravelerLocationTags", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Montanhas"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Praias"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cachoeiras"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Trilhas"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Pontos Turísticos"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lugares Históricos"
                        });
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate.TravelerProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("TravelerProfile", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea6f20a3-793c-460f-b145-c2979fdf6fd4"),
                            Description = "Para o perfil mochileiro o que importa é a jornada e as experiências adquiridas, o destino é apenas uma consequência.",
                            Name = "Mochileiro"
                        },
                        new
                        {
                            Id = new Guid("4680c0cf-e9e4-418e-b6a5-33c8aa0ff3d0"),
                            Description = "Você gosta de aproveitar tudo que o destino têm a oferecer, pontos turísticos, culinária, museus, parques, arquitetura e todo o resto.",
                            Name = "Turista"
                        },
                        new
                        {
                            Id = new Guid("bfc17798-2ac7-4d95-8143-9df5b65c28f6"),
                            Description = "O perfil fotógrafo gosta de tirar fotos de tudo que vê pela frente, registrar os momentos é o que é importante, detalhes pra você são a chave.",
                            Name = "Fotógrafo"
                        },
                        new
                        {
                            Id = new Guid("c0c3301b-8da6-4ad8-96e6-a90d154a1a86"),
                            Description = "Economia é tudo! Você quer aproveitar ao máximo gastando o menos possível, custo benefício é o seu foco.",
                            Name = "Econômico"
                        },
                        new
                        {
                            Id = new Guid("cfe98c44-604c-4794-ab7d-c83672b8fc78"),
                            Description = "Profundo, aprimorar o auto-conhecimento por meio de novas culturas, ensinamentos e buscar a paz interior é o seu foco.",
                            Name = "Auto Conhecedor"
                        },
                        new
                        {
                            Id = new Guid("8f183bd7-fb45-4c1d-9ec1-0fcd8cb66fc7"),
                            Description = "Viajar para conhecer novas pessoas, curtir com os amigos, família, é o seu objetivo, o que importa é estar perto de pessoas interessantes.",
                            Name = "Social"
                        });
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.Traveler", b =>
                {
                    b.HasOne("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.TravelerAverageSpend", "AverageSpend")
                        .WithOne()
                        .HasForeignKey("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.Traveler", "AverageSpendId");

                    b.HasOne("Traveler.Identity.Api.Domain.Aggregates.TravelerProfileAggregate.TravelerProfile", "Profile")
                        .WithOne()
                        .HasForeignKey("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.Traveler", "ProfileId");

                    b.Navigation("AverageSpend");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate.TravelerLocation", b =>
                {
                    b.HasOne("Traveler.Identity.Api.Domain.Aggregates.TravelerLocationAggregate.TravelerLocationTags", null)
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Traveler.Identity.Api.Domain.Aggregates.TravelerAggregate.Traveler", null)
                        .WithMany()
                        .HasForeignKey("TravelerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
