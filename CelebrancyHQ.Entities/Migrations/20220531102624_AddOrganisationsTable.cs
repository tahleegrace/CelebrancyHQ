using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddOrganisationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Organisations",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[] { 1, new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(3892), "CelebrancyHQ", new DateTime(2022, 5, 31, 10, 26, 24, 395, DateTimeKind.Utc).AddTicks(3894) });

            migrationBuilder.Sql("Update Persons SET OrganisationId = (Select Id From Organisations Where Name = 'CelebrancyHQ') Where EmailAddress = 'system.admin@celebrancyhq.co'");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons",
                column: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Organisations_OrganisationId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_Persons_OrganisationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
