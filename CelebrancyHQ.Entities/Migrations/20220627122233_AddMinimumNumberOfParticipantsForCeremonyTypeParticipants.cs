using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddMinimumNumberOfParticipantsForCeremonyTypeParticipants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), 1, new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), 1, new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), 2, new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), 1, new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), 1, new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 30, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeDates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "MinimumNumberOfParticipants", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeServiceProviders",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "DateOfBirth", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
