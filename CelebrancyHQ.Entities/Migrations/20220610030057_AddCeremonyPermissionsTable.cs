using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyPermissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeParticipantId = table.Column<int>(type: "int", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanView = table.Column<bool>(type: "bit", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    CanEditWithApproval = table.Column<bool>(type: "bit", nullable: false),
                    IsApprover = table.Column<bool>(type: "bit", nullable: false),
                    CanViewHistory = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyPermissions_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyPermissions_CeremonyTypeParticipants_CeremonyTypeParticipantId",
                        column: x => x.CeremonyTypeParticipantId,
                        principalTable: "CeremonyTypeParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyPermissions_CeremonyId",
                table: "CeremonyPermissions",
                column: "CeremonyId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyPermissions_CeremonyTypeParticipantId",
                table: "CeremonyPermissions",
                column: "CeremonyTypeParticipantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyPermissions");
        }
    }
}
