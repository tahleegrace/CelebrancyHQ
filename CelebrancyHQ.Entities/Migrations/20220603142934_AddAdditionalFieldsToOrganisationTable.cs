using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddAdditionalFieldsToOrganisationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Organisations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Organisations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "Type", "Updated", "Website" },
                values: new object[] { "info@celebrancyhq.co", "Celebrant", new DateTime(2022, 6, 3, 14, 29, 34, 86, DateTimeKind.Utc).AddTicks(2645), "https://www.celebrancyhq.co" });

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_AddressId",
                table: "Organisations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_Organisations_AddressId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Organisations");

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 14, 19, 15, 965, DateTimeKind.Utc).AddTicks(5144) });
        }
    }
}
