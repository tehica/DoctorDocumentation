using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorDoc1.Migrations
{
    public partial class NewMigrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: "11/24/2020");

            migrationBuilder.UpdateData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: "11/24/2020");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 1, 1 },
                column: "AcquiredAt",
                value: "11/23/2020");

            migrationBuilder.UpdateData(
                table: "Doctor_Specialization",
                keyColumns: new[] { "SpecializationId", "DoctorId" },
                keyValues: new object[] { 2, 2 },
                column: "AcquiredAt",
                value: "11/23/2020");
        }
    }
}
