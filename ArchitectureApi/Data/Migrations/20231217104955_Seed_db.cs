using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArchitectureApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "DoctorType", "Email", "FirstName", "LastName", "Phone", "PhotoFile", "Role", "SecondName" },
                values: new object[,]
                {
                    { 1, "Львів, вул. Жовківська, 39", null, "ruslan_p@gmail.com", "Руслан", "Ігорович", "095-655-65-89", "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956", "Patient", "Пундак" },
                    { 2, "Львів, вул. Київська, 49", "Стоматолог", "papa@gmail.com", "Папа", "Батьковтч", "097-586-55-25", "https://professions.ng/wp-content/uploads/2023/07/The-Process-of-Becoming-a-Doctor-in-Nigeria-A-Roadmap2-768x768.jpg", "Doctor", "Пйотр" },
                    { 3, "Львів, вул. Луганська, 77", "Стоматолог", "yukarp@gmail.com", "Карпінець", "Батькович", "097-785-55-25", "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*", "Doctor", "Юрій" },
                    { 4, "Львів, просп. Свободи, 21", "Стоматолог", "art_patskun@gmail.com", "Артур", "Батькович", "097-688-55-25", "https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "Doctor", "Пацкун" },
                    { 5, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 6, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 7, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 8, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 9, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 10, "Львів, вул. Жовківська, 39", null, "vika@gmail.com", "Вікторія", "Орестівна", "095-655-65-89", "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956", "Patient", "Анашян" },
                    { 11, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" },
                    { 12, "Львів, просп. Свободи, 21", "Педіатр", "papa@gmail.com", "Анастасія", "Іванівна", "097-586-55-25", "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg", "Doctor", "Зайчук" }
                });

            migrationBuilder.InsertData(
                table: "TimeSlots",
                columns: new[] { "Id", "DoctorId", "From", "To" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TimeSlots",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
