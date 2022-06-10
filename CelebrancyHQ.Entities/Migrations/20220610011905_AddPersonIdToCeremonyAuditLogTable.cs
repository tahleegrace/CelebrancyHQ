using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddPersonIdToCeremonyAuditLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "CeremonyAuditLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyAuditLogs_PersonId",
                table: "CeremonyAuditLogs",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyAuditLogs_Persons_PersonId",
                table: "CeremonyAuditLogs",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyAuditLogs_Persons_PersonId",
                table: "CeremonyAuditLogs");

            migrationBuilder.DropIndex(
                name: "IX_CeremonyAuditLogs_PersonId",
                table: "CeremonyAuditLogs");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "CeremonyAuditLogs");
        }
    }
}
