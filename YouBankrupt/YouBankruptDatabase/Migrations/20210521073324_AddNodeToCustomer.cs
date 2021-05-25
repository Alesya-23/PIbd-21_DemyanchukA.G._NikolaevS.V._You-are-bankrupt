using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class AddNodeToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditingCurrence",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditingId = table.Column<int>(nullable: false),
                    CurrenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditingCurrence", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditingCurrence_Creditings_CreditingId",
                        column: x => x.CreditingId,
                        principalTable: "Creditings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditingCurrence_Currences_CurrenceId",
                        column: x => x.CurrenceId,
                        principalTable: "Currences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditingCurrence_CreditingId",
                table: "CreditingCurrence",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditingCurrence_CurrenceId",
                table: "CreditingCurrence",
                column: "CurrenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditingCurrence");
        }
    }
}
