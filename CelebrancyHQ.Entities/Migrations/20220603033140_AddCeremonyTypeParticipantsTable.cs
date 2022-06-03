using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyTypeParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyTypeParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyTypeParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyTypeParticipants_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CeremonyTypeParticipants",
                columns: new[] { "Id", "CeremonyTypeId", "Code", "Created", "Description", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, 1, "Celebrant", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9938), null, "Celebrant", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9939) },
                    { 2, 2, "Celebrant", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9952), null, "Celebrant", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9952) },
                    { 3, 1, "Couple", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9957), null, "Couple", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9958) },
                    { 4, 1, "Organiser", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9963), null, "Organiser", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9963) },
                    { 5, 2, "Organiser", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9968), null, "Organiser", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9969) },
                    { 6, 1, "Witness", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9978), null, "Witness", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9979) },
                    { 7, 1, "BridalParty", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9984), null, "Bridal party", new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9984) },
                    { 8, 1, "InvitedGuest", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(60), null, "Invited guest", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(61) },
                    { 9, 2, "Deceased", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(66), null, "Deceased person", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(67) },
                    { 10, 2, "InvitedGuest", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(73), null, "Invited guest", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(74) },
                    { 11, 1, "Other", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(79), null, "Other", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(79) },
                    { 12, 2, "Other", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(84), null, "Other", new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(85) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyTypeParticipants_CeremonyTypeId",
                table: "CeremonyTypeParticipants",
                column: "CeremonyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyTypeParticipants");
        }
    }
}
