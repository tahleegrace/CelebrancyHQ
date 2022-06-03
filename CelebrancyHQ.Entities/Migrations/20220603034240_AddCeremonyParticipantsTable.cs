using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeParticipantId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_CeremonyTypeParticipants_CeremonyTypeParticipantId",
                        column: x => x.CeremonyTypeParticipantId,
                        principalTable: "CeremonyTypeParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_CeremonyId",
                table: "CeremonyParticipants",
                column: "CeremonyId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_CeremonyTypeParticipantId",
                table: "CeremonyParticipants",
                column: "CeremonyTypeParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_PersonId",
                table: "CeremonyParticipants",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyParticipants");
        }
    }
}
