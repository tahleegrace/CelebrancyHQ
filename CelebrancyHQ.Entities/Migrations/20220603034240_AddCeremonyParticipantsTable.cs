using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremonyParticipantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CeremonyParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeremonyId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CeremonyTypeParticipantId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CeremonyParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_Ceremonies_CeremonyId",
                        column: x => x.CeremonyId,
                        principalTable: "Ceremonies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_CeremonyTypeParticipants_CeremonyTypeParticipantId",
                        column: x => x.CeremonyTypeParticipantId,
                        principalTable: "CeremonyTypeParticipants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CeremonyParticipants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8643), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8644) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8657), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8662), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8667), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8672), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8673) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8681), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8686), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8687) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8691), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8696), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8702), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8707), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8708) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8712), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8481), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8496), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(7910), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(7913) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8186), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8187) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8318), new DateTime(2022, 6, 3, 3, 42, 39, 808, DateTimeKind.Utc).AddTicks(8319) });

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_CeremonyId",
                table: "CeremonyParticipants",
                column: "CeremonyId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_CeremonyTypeParticipantId",
                table: "CeremonyParticipants",
                column: "CeremonyTypeParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_CeremonyParticipants_PersonId",
                table: "CeremonyParticipants",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CeremonyParticipants");

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9938), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9939) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9952), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9952) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9957), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9963), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9968), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9978), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9979) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9984), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9984) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(60), new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(66), new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(73), new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(79), new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(79) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypeParticipants",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(84), new DateTime(2022, 6, 3, 3, 31, 39, 497, DateTimeKind.Utc).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9787), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9787) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9801), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9220), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9519), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9519) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9646), new DateTime(2022, 6, 3, 3, 31, 39, 496, DateTimeKind.Utc).AddTicks(9647) });
        }
    }
}
