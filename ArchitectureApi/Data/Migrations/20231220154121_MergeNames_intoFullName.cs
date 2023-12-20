using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchitectureApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MergeNames_intoFullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "FullName",
                value: "Руслан Пундак Ігорович");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "FullName",
                value: "Папа Пйотр Батьковтч");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "FullName",
                value: "Карпінець Юрій Батькович");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "Артур Пацкун Батькович");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "FullName",
                value: "Вікторія Анашян Орестівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "FullName",
                value: "Анастасія Зайчук Іванівна");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Руслан", "Ігорович", "Пундак" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Папа", "Батьковтч", "Пйотр" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Карпінець", "Батькович", "Юрій" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Артур", "Батькович", "Пацкун" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Вікторія", "Орестівна", "Анашян" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "FirstName", "LastName", "SecondName" },
                values: new object[] { "Анастасія", "Іванівна", "Зайчук" });
        }
    }
}
