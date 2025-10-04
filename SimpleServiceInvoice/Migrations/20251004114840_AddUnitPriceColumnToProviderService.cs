using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleServiceInvoice.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitPriceColumnToProviderService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "ProviderServices",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "ProviderServices");
        }
    }
}
