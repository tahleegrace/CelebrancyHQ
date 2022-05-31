using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddPersonsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Created", "EmailAddress", "FirstName", "LastName", "Updated" },
                values: new object[] { 1, new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(586), "system.admin@celebrancyhq.co", "CelebrancyHQ", "System Administrator", new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(798), new DateTime(2022, 5, 31, 9, 38, 39, 665, DateTimeKind.Utc).AddTicks(798) });

            migrationBuilder.Sql("Update Users SET PersonId = (Select Id From Persons Where EmailAddress = 'system.admin@celebrancyhq.co') Where EmailAddress = 'system.admin@celebrancyhq.co'");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Users",
                nullable: false
            );

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 5, 31, 5, 30, 51, 617, DateTimeKind.Utc).AddTicks(8393), new DateTime(2022, 5, 31, 5, 30, 51, 617, DateTimeKind.Utc).AddTicks(8396) });
        }
    }
}
