using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCeremoniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ceremonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CeremonyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CeremonyTypeId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceremonies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ceremonies_CeremonyTypes_CeremonyTypeId",
                        column: x => x.CeremonyTypeId,
                        principalTable: "CeremonyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(3083), new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(3096), new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(3097) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2527), new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2815), new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2815) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2947), new DateTime(2022, 6, 3, 2, 34, 20, 589, DateTimeKind.Utc).AddTicks(2947) });

            migrationBuilder.CreateIndex(
                name: "IX_Ceremonies_CeremonyTypeId",
                table: "Ceremonies",
                column: "CeremonyTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ceremonies");

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3162) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3172), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3173) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2627), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2942), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(2943) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3051), new DateTime(2022, 6, 1, 1, 57, 31, 953, DateTimeKind.Utc).AddTicks(3052) });
        }
    }
}
