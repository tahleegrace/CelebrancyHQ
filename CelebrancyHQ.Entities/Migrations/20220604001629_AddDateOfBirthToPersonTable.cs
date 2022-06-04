using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddDateOfBirthToPersonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 6, 4, 0, 16, 28, 829, DateTimeKind.Utc).AddTicks(4605) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 14, 29, 34, 86, DateTimeKind.Utc).AddTicks(2939) });
        }
    }
}
