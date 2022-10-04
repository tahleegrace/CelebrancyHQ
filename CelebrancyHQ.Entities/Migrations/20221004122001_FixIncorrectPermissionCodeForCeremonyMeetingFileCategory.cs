using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class FixIncorrectPermissionCodeForCeremonyMeetingFileCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CeremonyTypeFileCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionCode",
                value: "Meetings");

            migrationBuilder.UpdateData(
                table: "CeremonyTypeFileCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionCode",
                value: "Meetings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CeremonyTypeFileCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionCode",
                value: "Meeting");

            migrationBuilder.UpdateData(
                table: "CeremonyTypeFileCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionCode",
                value: "Meeting");
        }
    }
}
