using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrenceCrediting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrenceCId = table.Column<int>(nullable: false),
                    CreditingId = table.Column<int>(nullable: false),
                    CurrenceCreditingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrenceCrediting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrenceCrediting_Creditings_CurrenceCreditingId",
                        column: x => x.CurrenceCreditingId,
                        principalTable: "Creditings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrenceCrediting_Currences_CurrenceCreditingId",
                        column: x => x.CurrenceCreditingId,
                        principalTable: "Currences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrenceCrediting_CurrenceCreditingId",
                table: "CurrenceCrediting",
                column: "CurrenceCreditingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrenceCrediting");
        }
    }
}
