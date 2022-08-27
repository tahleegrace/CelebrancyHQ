using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyIdFieldToCeremonyMeetingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CeremonyId",
                table: "CeremonyMeetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetings_CeremonyId",
                table: "CeremonyMeetings",
                column: "CeremonyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyMeetings_Ceremonies_CeremonyId",
                table: "CeremonyMeetings",
                column: "CeremonyId",
                principalTable: "Ceremonies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyMeetings_Ceremonies_CeremonyId",
                table: "CeremonyMeetings");

            migrationBuilder.DropIndex(
                name: "IX_CeremonyMeetings_CeremonyId",
                table: "CeremonyMeetings");

            migrationBuilder.DropColumn(
                name: "CeremonyId",
                table: "CeremonyMeetings");
        }
    }
}
