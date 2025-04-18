using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedingStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "RollNo" },
                values: new object[,]
                {
                    { -3, "21r21a62A9@mlrinstitutions.ac.in", "Dineah Palapothula", "21r21a62A9" },
                    { -2, "21r21a62C0@mlrinstitutions.ac.in", "Vemula Abhiram", "21r21a62C0" },
                    { -1, "21r21a6273@mlrinstitutions.ac.in", "Karthik Balabathula", "21r21a6273" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "StudentId", "Zip" },
                values: new object[,]
                {
                    { -3, "Hyderabad", "India", "Telangana", -3, 500043 },
                    { -2, "Hyderabad", "India", "Telangana", -2, 500043 },
                    { -1, "Hyderabad", "India", "Telangana", -1, 500072 }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "Specialisation", "StudentId" },
                values: new object[,]
                {
                    { -3, "ComputerScience", "cyberSecurity", -3 },
                    { -2, "ComputerScience", "cyberSecurity", -2 },
                    { -1, "ComputerScience", "cyberSecurity", -1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
