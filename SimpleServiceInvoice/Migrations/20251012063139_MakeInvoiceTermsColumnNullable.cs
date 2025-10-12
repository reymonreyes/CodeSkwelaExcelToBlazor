using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleServiceInvoice.Migrations
{
    /// <inheritdoc />
    public partial class MakeInvoiceTermsColumnNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                table: "Invoices",
                name: "Terms",
                type: "TEXT",
                oldType: "TEXT",
                nullable: true
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
