using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyFormResponsesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyFormResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyFormId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeFormFieldId = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyFormResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyFormResponses_CeremonyForms_CeremonyFormId",
                        column: x => x.CeremonyFormId,
                        principalTable: "CeremonyForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyFormResponses_CeremonyTypeFormFields_CeremonyTypeFormFieldId",
                        column: x => x.CeremonyTypeFormFieldId,
                        principalTable: "CeremonyTypeFormFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyFormResponses_CeremonyFormId",
                table: "CeremonyFormResponses",
                column: "CeremonyFormId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyFormResponses_CeremonyTypeFormFieldId",
                table: "CeremonyFormResponses",
                column: "CeremonyTypeFormFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyFormResponses");
        }
    }
}
