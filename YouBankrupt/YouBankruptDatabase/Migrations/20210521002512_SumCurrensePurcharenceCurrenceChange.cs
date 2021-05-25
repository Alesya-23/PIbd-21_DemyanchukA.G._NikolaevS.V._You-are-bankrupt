using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class SumCurrensePurcharenceCurrenceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summ",
                table: "PurchasesCurrences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Summ",
                table: "PurchasesCurrences",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
