using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddNotificationCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationCategories_NotificationCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "NotificationCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "NotificationCategories",
                columns: new[] { "Id", "Code", "Created", "Deleted", "Description", "Name", "ParentCategoryId", "Updated" },
                values: new object[,]
                {
                    { 1, "Ceremonies", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Ceremonies", null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "CeremonyTypes", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Ceremony Types", null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Organisations", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Organisations", null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "Persons", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Persons", null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "Files", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Files", null, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "NotificationCategories",
                columns: new[] { "Id", "Code", "Created", "Deleted", "Description", "Name", "ParentCategoryId", "Updated" },
                values: new object[] { 6, "ParticipantAdded", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, "A participant has been added to a ceremony", "Ceremonies", 1, new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationCategories_ParentCategoryId",
                table: "NotificationCategories",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationCategories");
        }
    }
}
