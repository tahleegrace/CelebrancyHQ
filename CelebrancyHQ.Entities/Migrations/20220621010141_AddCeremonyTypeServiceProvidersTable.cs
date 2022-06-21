using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeServiceProvidersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeServiceProviders",
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
                    table.PrimaryKey("PK_CeremonyTypeServiceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeServiceProviders_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypeServiceProviders",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Deleted", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "Photographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Photographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 2, "Photographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Photographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, "Videographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Videographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, "Videographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Videographer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 1, "Musician", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Musician", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 2, "Musician", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Musician", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 1, "Caterer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Caterer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 2, "Caterer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Caterer", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 1, "Calligrapher", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Calligrapher", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 2, "Calligrapher", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Calligrapher", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 1, "Florist", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Florist", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 2, "Florist", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Florist", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 2, "FuneralDirector", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc), false, null, "Funeral Director", new DateTime(2022, 5, 8, 14, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeServiceProviders_CeremonyTypeId",
                table: "CeremonyTypeServiceProviders",
                column: "CeremonyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeServiceProviders");
        }
    }
}
