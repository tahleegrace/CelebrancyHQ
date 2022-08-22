using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeMeetingQuestionTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeMeetingQuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeMeetingQuestionTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypeMeetingQuestionTypes",
                columns: new[] { "Id", "Code", "Created", "Deleted", "Description", "Updated" },
                values: new object[,]
                {
                    { 1, "Text", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A field that can accept text or HTML data.", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Dropdown", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A field that allows the user to select one option from a list.", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Checkboxes", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A field that allows the user to select zero or more options from a row of checkboxes.", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "Image", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A field that allows the user to select an image.", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "File", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A field that allows the user to select a file.", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeMeetingQuestionTypes");
        }
    }
}
