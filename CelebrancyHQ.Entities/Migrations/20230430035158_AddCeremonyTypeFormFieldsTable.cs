using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeFormFieldsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeFormFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    FormFieldTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExplanatoryText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeFormFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeFormFields_CeremonyTypeForms_FormId",
                        column: x => x.FormId,
                        principalTable: "CeremonyTypeForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeFormFields_CeremonyTypeFormSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "CeremonyTypeFormSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeFormFields_FormFieldTypes_FormFieldTypeId",
                        column: x => x.FormFieldTypeId,
                        principalTable: "FormFieldTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeFormFields_FormFieldTypeId",
                table: "CeremonyTypeFormFields",
                column: "FormFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeFormFields_FormId",
                table: "CeremonyTypeFormFields",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeFormFields_SectionId",
                table: "CeremonyTypeFormFields",
                column: "SectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeFormFields");
        }
    }
}
