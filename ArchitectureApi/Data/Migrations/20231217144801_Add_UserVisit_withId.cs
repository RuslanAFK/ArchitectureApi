using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchitectureApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_UserVisit_withId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVisit_Users_ParticipantsId",
                table: "UserVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVisit",
                table: "UserVisit");

            migrationBuilder.RenameColumn(
                name: "ParticipantsId",
                table: "UserVisit",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserVisit",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVisit",
                table: "UserVisit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserVisit_UserId",
                table: "UserVisit",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVisit_Users_UserId",
                table: "UserVisit",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVisit_Users_UserId",
                table: "UserVisit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVisit",
                table: "UserVisit");

            migrationBuilder.DropIndex(
                name: "IX_UserVisit_UserId",
                table: "UserVisit");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserVisit");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserVisit",
                newName: "ParticipantsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVisit",
                table: "UserVisit",
                columns: new[] { "ParticipantsId", "VisitId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserVisit_Users_ParticipantsId",
                table: "UserVisit",
                column: "ParticipantsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
