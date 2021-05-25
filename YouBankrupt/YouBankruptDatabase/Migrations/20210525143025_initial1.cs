using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrenceId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchasesCurrenceId",
                table: "Payments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrenceId",
                table: "Creditings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrenceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PurchasesCurrenceId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CurrenceId",
                table: "Creditings");
        }
    }
}
