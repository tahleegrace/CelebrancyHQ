using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddInterpreterAndFuneralDirectorCeremonyTypeParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CeremonyTypeParticipants",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[] { 13, 1, "Interpreter", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Interpreter", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "CeremonyTypeParticipants",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[] { 14, 2, "Interpreter", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Interpreter", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "CeremonyTypeParticipants",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[] { 15, 2, "FuneralDirector", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Funeral director", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
