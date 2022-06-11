using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddDateOfDeathCeremonyTypeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CeremonyTypeDates",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[] { 13, 2, "Death", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Death", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
