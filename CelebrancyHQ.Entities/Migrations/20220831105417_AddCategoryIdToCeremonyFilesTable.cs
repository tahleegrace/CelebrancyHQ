using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCategoryIdToCeremonyFilesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "CeremonyFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyFiles_CategoryId",
                table: "CeremonyFiles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CeremonyFiles_CeremonyTypeFileCategories_CategoryId",
                table: "CeremonyFiles",
                column: "CategoryId",
                principalTable: "CeremonyTypeFileCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CeremonyFiles_CeremonyTypeFileCategories_CategoryId",
                table: "CeremonyFiles");

            migrationBuilder.DropIndex(
                name: "IX_CeremonyFiles_CategoryId",
                table: "CeremonyFiles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CeremonyFiles");
        }
    }
}
