using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelebrancyHQ.Entities.Migrations
{
    public partial class AddCodeToCeremonyTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "CeremonyTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "Created", "Updated" },
                values: new object[] { "Marriage", new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5427), new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "CeremonyTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "Created", "Updated" },
                values: new object[] { "Funeral", new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5436), new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5437) });

            migrationBuilder.UpdateData(
                table: "Organisations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(4742), new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5024), new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "Updated" },
                values: new object[] { new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5154), new DateTime(2022, 6, 3, 2, 46, 59, 222, DateTimeKind.Utc).AddTicks(5155) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "CeremonyTypes");

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
        }
    }
}
