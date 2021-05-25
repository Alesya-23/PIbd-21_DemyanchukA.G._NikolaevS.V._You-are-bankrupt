using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class intial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreditingProgramId",
                table: "Transactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditingProgramId",
                table: "Transactions",
                type: "int",
                nullable: true);
        }
    }
}
