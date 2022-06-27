using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddRequiresAddressAndRequiresPhoneNumberFieldsToCeremonyTypeParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequiresAddress",
                table: "CeremonyTypeParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresPhoneNumber",
                table: "CeremonyTypeParticipants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14,
                column: "RequiresPhoneNumber",
                value: true);

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "RequiresAddress", "RequiresPhoneNumber" },
                values: new object[] { true, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiresAddress",
                table: "CeremonyTypeParticipants");

            migrationBuilder.DropColumn(
                name: "RequiresPhoneNumber",
                table: "CeremonyTypeParticipants");
        }
    }
}
