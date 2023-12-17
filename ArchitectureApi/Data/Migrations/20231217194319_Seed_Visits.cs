using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArchitectureApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Visits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Visits",
                columns: new[] { "Id", "Notes", "Time", "Treatment" },
                values: new object[,]
                {
                    { 2, "Болить горло", new DateTime(2023, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), "Прополоскати горло" },
                    { 3, "Болить живіт", new DateTime(2023, 12, 28, 14, 0, 0, 0, DateTimeKind.Unspecified), "Випити ліки від болю в животі" }
                });

            migrationBuilder.InsertData(
                table: "UserVisit",
                columns: new[] { "Id", "UserId", "VisitId" },
                values: new object[,]
                {
                    { 3, 1, 2 },
                    { 4, 10, 3 },
                    { 5, 4, 2 },
                    { 6, 6, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserVisit",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserVisit",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserVisit",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserVisit",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Visits",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
