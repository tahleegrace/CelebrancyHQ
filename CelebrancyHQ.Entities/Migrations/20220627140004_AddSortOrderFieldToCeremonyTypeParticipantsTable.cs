using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddSortOrderFieldToCeremonyTypeParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "CeremonyTypeParticipants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                column: "SortOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                column: "SortOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                column: "SortOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                column: "SortOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                column: "SortOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 7,
                column: "SortOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 8,
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                column: "SortOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 10,
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 11,
                column: "SortOrder",
                value: 8);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 12,
                column: "SortOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 13,
                column: "SortOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14,
                column: "SortOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 15,
                column: "SortOrder",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "CeremonyTypeParticipants");
        }
    }
}
