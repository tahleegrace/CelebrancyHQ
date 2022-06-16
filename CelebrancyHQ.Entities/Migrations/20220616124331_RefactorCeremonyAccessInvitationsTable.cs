using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class RefactorCeremonyAccessInvitationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyAccessInvitations_CeremonyParticipants_CeremonyParticipantId",
                table: "CeremonyAccessInvitations");

            migrationBuilder.RenameColumn(
                name: "CeremonyParticipantId",
                table: "CeremonyAccessInvitations",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_CeremonyAccessInvitations_CeremonyParticipantId",
                table: "CeremonyAccessInvitations",
                newName: "IX_CeremonyAccessInvitations_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "CeremonyId",
                table: "CeremonyAccessInvitations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyAccessInvitations_CeremonyId",
                table: "CeremonyAccessInvitations",
                column: "CeremonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyAccessInvitations_Ceremonies_CeremonyId",
                table: "CeremonyAccessInvitations",
                column: "CeremonyId",
                principalTable: "Ceremonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyAccessInvitations_Persons_PersonId",
                table: "CeremonyAccessInvitations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyAccessInvitations_Ceremonies_CeremonyId",
                table: "CeremonyAccessInvitations");

            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyAccessInvitations_Persons_PersonId",
                table: "CeremonyAccessInvitations");

            migrationBuilder.DropIndex(
                name: "IX_CeremonyAccessInvitations_CeremonyId",
                table: "CeremonyAccessInvitations");

            migrationBuilder.DropColumn(
                name: "CeremonyId",
                table: "CeremonyAccessInvitations");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "CeremonyAccessInvitations",
                newName: "CeremonyParticipantId");

            migrationBuilder.RenameIndex(
                name: "IX_CeremonyAccessInvitations_PersonId",
                table: "CeremonyAccessInvitations",
                newName: "IX_CeremonyAccessInvitations_CeremonyParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyAccessInvitations_CeremonyParticipants_CeremonyParticipantId",
                table: "CeremonyAccessInvitations",
                column: "CeremonyParticipantId",
                principalTable: "CeremonyParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
