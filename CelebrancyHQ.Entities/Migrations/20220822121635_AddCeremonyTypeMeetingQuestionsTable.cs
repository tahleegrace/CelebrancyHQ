using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeMeetingQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeMeetingQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyTypeMeetingId = table.Column<int>(type: "int", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Options = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeMeetingQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeMeetingQuestions_CeremonyTypeMeetingQuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "CeremonyTypeMeetingQuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeMeetingQuestions_CeremonyTypeMeetings_CeremonyTypeMeetingId",
                        column: x => x.CeremonyTypeMeetingId,
                        principalTable: "CeremonyTypeMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeMeetingQuestions_CeremonyTypeMeetingId",
                table: "CeremonyTypeMeetingQuestions",
                column: "CeremonyTypeMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeMeetingQuestions_QuestionTypeId",
                table: "CeremonyTypeMeetingQuestions",
                column: "QuestionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeMeetingQuestions");
        }
    }
}
