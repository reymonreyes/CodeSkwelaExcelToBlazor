using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeeklyTimesheet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTimesheetLogsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimesheetLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimesheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayOfWeek = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BreakMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeOut = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OvertimeMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    SickMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    HolidayMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    VacationMinutes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesheetLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimesheetLogs_Timesheets_TimesheetId",
                        column: x => x.TimesheetId,
                        principalTable: "Timesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimesheetLogs_TimesheetId",
                table: "TimesheetLogs",
                column: "TimesheetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesheetLogs");
        }
    }
}
