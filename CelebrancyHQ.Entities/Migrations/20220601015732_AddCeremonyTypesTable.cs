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

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypes_OrganisationId",
                table: "CeremonyTypes",
                column: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypes");
        }
    }
}
