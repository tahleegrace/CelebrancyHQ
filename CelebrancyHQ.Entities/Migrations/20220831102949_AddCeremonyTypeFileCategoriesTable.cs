using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeFileCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeFileCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeFileCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeFileCategories_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypeFileCategories",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "PermissionCode", "Updated" },
                values: new object[] { 1, 1, "Meeting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "A meeting with another ceremony participant.", "Meeting", "Meeting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CeremonyTypeFileCategories",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "PermissionCode", "Updated" },
                values: new object[] { 2, 2, "Meeting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "A meeting with another ceremony participant.", "Meeting", "Meeting", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeFileCategories_CeremonyTypeId",
                table: "CeremonyTypeFileCategories",
                column: "CeremonyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeFileCategories");
        }
    }
}
