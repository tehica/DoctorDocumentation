using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorDoc1.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Zagreb", "10000" },
                    { 2, "Rijeka", "51000" },
                    { 3, "Osijek", "63274" }
                });

            migrationBuilder.InsertData(
                table: "Qualification",
                columns: new[] { "Id", "InstituteName", "Name" },
                values: new object[,]
                {
                    { 1, "VVG", "Qualification1" },
                    { 2, "TVZ", "Qualification2" },
                    { 3, "FER", "Qualification3" }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Specialization1" },
                    { 2, "Specialization2" }
                });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 2, "Bolnica1" });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 2, 2, "Bolnica2" });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 3, 2, "Bolnica3" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "HospitalId", "LastName", "PhoneNumber" },
                values: new object[] { 1, "tehica97@gmail.com", "Toni", "Male", 1, "Musa", "0955335829" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "HospitalId", "LastName", "PhoneNumber" },
                values: new object[] { 2, "marko.maric1@gmail.com", "Marko", "Male", 2, "Marić", "0927549283" });

            migrationBuilder.InsertData(
                table: "Doctor_Specialization",
                columns: new[] { "SpecializationId", "DoctorId", "AcquiredAt" },
                values: new object[] { 1, 1, "11/23/2020" });

            migrationBuilder.InsertData(
                table: "Doctor_Specialization",
                columns: new[] { "SpecializationId", "DoctorId", "AcquiredAt" },
                values: new object[] { 2, 2, "11/23/2020" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualification",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialization",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospital",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
