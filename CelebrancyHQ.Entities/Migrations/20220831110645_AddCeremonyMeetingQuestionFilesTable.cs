using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyMeetingQuestionFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyMeetingQuestions_Files_FileId",
                table: "CeremonyMeetingQuestions");

            migrationBuilder.DropIndex(
                name: "IX_CeremonyMeetingQuestions_FileId",
                table: "CeremonyMeetingQuestions");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "CeremonyMeetingQuestions");

            migrationBuilder.CreateTable(
                name: "CeremonyMeetingQuestionFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyMeetingQuestionFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyMeetingQuestionFiles_CeremonyFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "CeremonyFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyMeetingQuestionFiles_CeremonyMeetingQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "CeremonyMeetingQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestionFiles_FileId",
                table: "CeremonyMeetingQuestionFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestionFiles_QuestionId",
                table: "CeremonyMeetingQuestionFiles",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyMeetingQuestionFiles");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "CeremonyMeetingQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyMeetingQuestions_FileId",
                table: "CeremonyMeetingQuestions",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyMeetingQuestions_Files_FileId",
                table: "CeremonyMeetingQuestions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id");
        }
    }
}
