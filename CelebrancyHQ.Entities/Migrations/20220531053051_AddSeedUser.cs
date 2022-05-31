using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddSeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "EmailAddress", "PasswordHash", "PasswordSalt", "Updated" },
                values: new object[] { 1, new DateTime(2022, 5, 31, 5, 30, 51, 617, DateTimeKind.Utc).AddTicks(8393), "system.admin@celebrancyhq.co", "testpassword", "passwordsalt", new DateTime(2022, 5, 31, 5, 30, 51, 617, DateTimeKind.Utc).AddTicks(8396) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
