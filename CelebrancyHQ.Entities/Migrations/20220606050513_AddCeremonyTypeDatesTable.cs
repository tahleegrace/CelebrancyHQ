using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeDatesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeDates_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypeDates",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "InitialPhoneCall", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Initial phone call", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, "InitialInterview", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Initial interview", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, "Rehearsal", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Rehearsal", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 1, "Ceremony", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Ceremony", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 1, "Reception", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Reception", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 1, "Other", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Other", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 2, "InitialPhoneCall", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Initial phone call", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 2, "InitialInterview", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Initial interview", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 2, "Rehearsal", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Rehearsal", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 2, "Ceremony", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Ceremony", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 2, "Wake", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Wake", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 2, "Other", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Other", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeDates_CeremonyTypeId",
                table: "CeremonyTypeDates",
                column: "CeremonyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeDates");
        }
    }
}
