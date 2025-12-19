using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyTimesheet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRateColumnsToTimesheetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HolidayLeaveRate",
                table: "Timesheets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OvertimeRate",
                table: "Timesheets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RegularRate",
                table: "Timesheets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SickLeaveRate",
                table: "Timesheets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "VacationLeaveRate",
                table: "Timesheets",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HolidayLeaveRate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "OvertimeRate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "RegularRate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "SickLeaveRate",
                table: "Timesheets");

            migrationBuilder.DropColumn(
                name: "VacationLeaveRate",
                table: "Timesheets");
        }
    }
}
