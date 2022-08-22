using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeMeetingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeMeetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyTypeId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeMeetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeMeetings_CeremonyTypeMeetings_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "CeremonyTypeMeetings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CeremonyTypeMeetings_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeMeetings_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeMeetings_CeremonyTypeId",
                table: "CeremonyTypeMeetings",
                column: "CeremonyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeMeetings_OrganisationId",
                table: "CeremonyTypeMeetings",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeMeetings_TemplateId",
                table: "CeremonyTypeMeetings",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeMeetings");
        }
    }
}
