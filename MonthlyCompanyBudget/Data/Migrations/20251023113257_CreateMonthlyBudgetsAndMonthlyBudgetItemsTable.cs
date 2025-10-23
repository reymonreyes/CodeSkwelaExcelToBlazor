using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonthlyCompanyBudget.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateMonthlyBudgetsAndMonthlyBudgetItemsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthlyBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyBudgetItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonthlyBudgetId = table.Column<int>(type: "INTEGER", nullable: false),
                    BudgetItemTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstimatedValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualValue = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyBudgetItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyBudgetItems_MonthlyBudgets_MonthlyBudgetId",
                        column: x => x.MonthlyBudgetId,
                        principalTable: "MonthlyBudgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyBudgetItems_MonthlyBudgetId",
                table: "MonthlyBudgetItems",
                column: "MonthlyBudgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonthlyBudgetItems");

            migrationBuilder.DropTable(
                name: "MonthlyBudgets");
        }
    }
}
