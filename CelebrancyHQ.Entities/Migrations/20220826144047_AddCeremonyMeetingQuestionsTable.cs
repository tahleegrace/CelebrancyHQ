using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyMeetingQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyMeetingQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyMeetingId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeMeetingQuestionId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyMeetingQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyMeetingQuestions_CeremonyMeetings_CeremonyMeetingId",
                        column: x => x.CeremonyMeetingId,
                        principalTable: "CeremonyMeetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyMeetingQuestions_CeremonyTypeMeetingQuestions_CeremonyTypeMeetingQuestionId",
                        column: x => x.CeremonyTypeMeetingQuestionId,
                        principalTable: "CeremonyTypeMeetingQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyMeetingQuestions_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestions_CeremonyMeetingId",
                table: "CeremonyMeetingQuestions",
                column: "CeremonyMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestions_CeremonyTypeMeetingQuestionId",
                table: "CeremonyMeetingQuestions",
                column: "CeremonyTypeMeetingQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestions_FileId",
                table: "CeremonyMeetingQuestions",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyMeetingQuestions");
        }
    }
}
