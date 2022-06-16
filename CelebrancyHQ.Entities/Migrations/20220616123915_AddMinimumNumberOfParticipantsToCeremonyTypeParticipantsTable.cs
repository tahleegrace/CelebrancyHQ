using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddMinimumNumberOfParticipantsToCeremonyTypeParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinimumNumberOfParticipants",
                table: "CeremonyTypeParticipants",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                column: "MinimumNumberOfParticipants",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinimumNumberOfParticipants",
                table: "CeremonyTypeParticipants");
        }
    }
}
