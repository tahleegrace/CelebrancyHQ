using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddPreferredNameTitleAndGenderToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Gender", "PreferredName", "Title", "Updated" },
                values: new object[] { "Other", "System Administrator", "Mx", new DateTime(2022, 6, 3, 10, 42, 4, 347, DateTimeKind.Utc).AddTicks(5094) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PreferredName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] {  "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 10, 5, 3, 595, DateTimeKind.Utc).AddTicks(685) });
        }
    }
}
