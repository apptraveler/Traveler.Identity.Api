using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traveler.Identity.Api.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelerAverageSpend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerAverageSpend", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelerLocationTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerLocationTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelerProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traveler",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ProfileId = table.Column<Guid>(type: "TEXT", nullable: true),
                    AverageSpendId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traveler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Traveler_TravelerAverageSpend_AverageSpendId",
                        column: x => x.AverageSpendId,
                        principalTable: "TravelerAverageSpend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Traveler_TravelerProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "TravelerProfile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TravelerLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TravelerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelerLocation_Traveler_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Traveler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelerLocation_TravelerLocationTags_LocationId",
                        column: x => x.LocationId,
                        principalTable: "TravelerLocationTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TravelerAverageSpend",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Baixo" });

            migrationBuilder.InsertData(
                table: "TravelerAverageSpend",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Médio" });

            migrationBuilder.InsertData(
                table: "TravelerAverageSpend",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Alto" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Montanhas" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Praias" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Cachoeiras" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Trilhas" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Pontos Turísticos" });

            migrationBuilder.InsertData(
                table: "TravelerLocationTags",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Lugares Históricos" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("0309de4d-3ca2-4ba6-abcd-655d71709785"), "Você gosta de aproveitar tudo que o destino têm a oferecer, pontos turísticos, culinária, museus, parques, arquitetura e todo o resto.", "Turista" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("10e60d29-0848-4208-a723-ea157e5a13e3"), "Profundo, aprimorar o auto-conhecimento por meio de novas culturas, ensinamentos e buscar a paz interior é o seu foco.", "Auto Conhecedor" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("83ffa673-96a7-4bf6-89c4-b86948ce5871"), "Viajar para conhecer novas pessoas, curtir com os amigos, família, é o seu objetivo, o que importa é estar perto de pessoas interessantes.", "Social" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("b509f797-f903-4bae-a09d-4b237713f5e7"), "Para o perfil mochileiro o que importa é a jornada e as experiências adquiridas, o destino é apenas uma consequência.", "Mochileiro" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("bfd66e39-6350-4778-866c-02c41cf177a7"), "O perfil fotógrafo gosta de tirar fotos de tudo que vê pela frente, registrar os momentos é o que é importante, detalhes pra você são a chave.", "Fotógrafo" });

            migrationBuilder.InsertData(
                table: "TravelerProfile",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("ecdcd222-b1e0-4299-b8bd-05fd8be1012d"), "Economia é tudo! Você quer aproveitar ao máximo gastando o menos possível, custo benefício é o seu foco.", "Econômico" });

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_AverageSpendId",
                table: "Traveler",
                column: "AverageSpendId");

            migrationBuilder.CreateIndex(
                name: "IX_Traveler_ProfileId",
                table: "Traveler",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerLocation_LocationId",
                table: "TravelerLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelerLocation_TravelerId",
                table: "TravelerLocation",
                column: "TravelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelerLocation");

            migrationBuilder.DropTable(
                name: "Traveler");

            migrationBuilder.DropTable(
                name: "TravelerLocationTags");

            migrationBuilder.DropTable(
                name: "TravelerAverageSpend");

            migrationBuilder.DropTable(
                name: "TravelerProfile");
        }
    }
}
