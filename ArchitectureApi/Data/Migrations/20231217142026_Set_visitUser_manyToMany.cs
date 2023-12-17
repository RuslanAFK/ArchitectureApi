using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchitectureApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Set_visitUser_manyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVisit_Visits_VisitsId",
                table: "UserVisit");

            migrationBuilder.RenameColumn(
                name: "VisitsId",
                table: "UserVisit",
                newName: "VisitId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVisit_VisitsId",
                table: "UserVisit",
                newName: "IX_UserVisit_VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVisit_Visits_VisitId",
                table: "UserVisit",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVisit_Visits_VisitId",
                table: "UserVisit");

            migrationBuilder.RenameColumn(
                name: "VisitId",
                table: "UserVisit",
                newName: "VisitsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVisit_VisitId",
                table: "UserVisit",
                newName: "IX_UserVisit_VisitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVisit_Visits_VisitsId",
                table: "UserVisit",
                column: "VisitsId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
