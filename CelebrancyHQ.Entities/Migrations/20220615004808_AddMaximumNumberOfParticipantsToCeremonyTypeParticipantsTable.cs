using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddMaximumNumberOfParticipantsToCeremonyTypeParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaximumNumberOfParticipants",
                table: "CeremonyTypeParticipants",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaximumNumberOfParticipants",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaximumNumberOfParticipants",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaximumNumberOfParticipants",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                column: "MaximumNumberOfParticipants",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                column: "MaximumNumberOfParticipants",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 13,
                column: "MaximumNumberOfParticipants",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14,
                column: "MaximumNumberOfParticipants",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumNumberOfParticipants",
                table: "CeremonyTypeParticipants");
        }
    }
}
