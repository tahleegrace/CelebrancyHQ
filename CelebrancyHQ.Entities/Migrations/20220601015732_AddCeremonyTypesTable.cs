using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypes_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypes",
                columns: new[] { "Id", "Created", "Description", "Name", "OrganisationId", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162), "A ceremony to celebrate the joining of two persons in marriage.", "Marriage Ceremony", null, new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162) },
                    { 2, new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3172), "A ceremony to celebrate the life of and remember a person who has recently passed way.", "Funeral Ceremony", null, new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3173) }
                });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2627), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2942), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2943) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3051), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3052) });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypes_OrganisationId",
                table: "CeremonyTypes",
                column: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypes");

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(3892), new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(3894) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(4203), new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(4323), new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(4323) });
        }
    }
}
