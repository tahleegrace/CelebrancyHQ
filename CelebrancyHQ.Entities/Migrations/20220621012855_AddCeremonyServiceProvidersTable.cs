using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyServiceProvidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyId = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyServiceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyServiceProviders_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyServiceProviders_CeremonyTypeServiceProviders_CeremonyTypeServiceProviderId",
                        column: x => x.CeremonyTypeServiceProviderId,
                        principalTable: "CeremonyTypeServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyServiceProviders_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyServiceProviders_CeremonyId",
                table: "CeremonyServiceProviders",
                column: "CeremonyId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyServiceProviders_CeremonyTypeServiceProviderId",
                table: "CeremonyServiceProviders",
                column: "CeremonyTypeServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyServiceProviders_OrganisationId",
                table: "CeremonyServiceProviders",
                column: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyServiceProviders");
        }
    }
}
