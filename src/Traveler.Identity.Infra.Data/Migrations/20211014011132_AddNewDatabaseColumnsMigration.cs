using Microsoft.EntityFrameworkCore.Migrations;

namespace Traveler.Identity.Infra.Data.Migrations
{
    public partial class AddNewDatabaseColumnsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "journeyername",
                table: "journeyer",
                newName: "username");

            migrationBuilder.AddColumn<bool>(
                name: "isFirstLogin",
                table: "journeyer",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFirstLogin",
                table: "journeyer");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "journeyer",
                newName: "journeyername");
        }
    }
}
