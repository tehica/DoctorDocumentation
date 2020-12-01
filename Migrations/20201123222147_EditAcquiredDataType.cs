using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorDoc1.Migrations
{
    public partial class EditAcquiredDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AcquiredAt",
                table: "Doctor_Specialization",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "AcquiredAt",
                table: "Doctor_Qualification",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AcquiredAt",
                table: "Doctor_Specialization",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "AcquiredAt",
                table: "Doctor_Qualification",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
