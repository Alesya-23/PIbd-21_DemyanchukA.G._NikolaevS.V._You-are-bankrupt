using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class AddSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Creditings_Customer_CustomerId",
                table: "Creditings");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Creditings_CreditingId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Customer_CustomerId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionWithCustomers_CreditPrograms_CreditProgramId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionWithCustomers_Creditings_CreditingId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionWithCustomers_Customer_CustomerId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropTable(
                name: "CurrenceCrediting");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_TransactionWithCustomers_CreditProgramId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropIndex(
                name: "IX_TransactionWithCustomers_CreditingId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropIndex(
                name: "IX_TransactionWithCustomers_CustomerId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CreditingId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Creditings_CustomerId",
                table: "Creditings");

            migrationBuilder.DropColumn(
                name: "CreditingId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropColumn(
                name: "CreditingProgramId",
                table: "TransactionWithCustomers");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "PurchasesCurrenceCurrences");

            migrationBuilder.DropColumn(
                name: "CreditingId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Creditings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "TransactionWithCustomers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CreditProgramName",
                table: "TransactionWithCustomers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomerFullName",
                table: "TransactionWithCustomers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Payments",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionWithCustomerId",
                table: "Payments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Currences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "CreditPrograms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionWithCustomerId",
                table: "Creditings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Payments",
                table: "Payments",
                column: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Currences_SupplierId",
                table: "Currences",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPrograms_SupplierId",
                table: "CreditPrograms",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditPrograms_Suppliers_SupplierId",
                table: "CreditPrograms",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Currences_Suppliers_SupplierId",
                table: "Currences",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_TransactionWithCustomers_Payments",
                table: "Payments",
                column: "Payments",
                principalTable: "TransactionWithCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditPrograms_Suppliers_SupplierId",
                table: "CreditPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_Currences_Suppliers_SupplierId",
                table: "Currences");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_TransactionWithCustomers_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_Payments",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Currences_SupplierId",
                table: "Currences");

            migrationBuilder.DropIndex(
                name: "IX_CreditPrograms_SupplierId",
                table: "CreditPrograms");

            migrationBuilder.DropColumn(
                name: "CreditProgramName",
                table: "TransactionWithCustomers");

            migrationBuilder.DropColumn(
                name: "CustomerFullName",
                table: "TransactionWithCustomers");

            migrationBuilder.DropColumn(
                name: "Payments",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "TransactionWithCustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Currences");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "CreditPrograms");

            migrationBuilder.DropColumn(
                name: "TransactionWithCustomerId",
                table: "Creditings");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "TransactionWithCustomers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditingId",
                table: "TransactionWithCustomers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditingProgramId",
                table: "TransactionWithCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "PurchasesCurrenceCurrences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreditingId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Creditings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurrenceCrediting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditingId = table.Column<int>(type: "int", nullable: false),
                    CurrenceCId = table.Column<int>(type: "int", nullable: false),
                    CurrenceCreditingId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionWithCustomers_CreditProgramId",
                table: "TransactionWithCustomers",
                column: "CreditProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionWithCustomers_CreditingId",
                table: "TransactionWithCustomers",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionWithCustomers_CustomerId",
                table: "TransactionWithCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreditingId",
                table: "Payments",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Creditings_CustomerId",
                table: "Creditings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrenceCrediting_CurrenceCreditingId",
                table: "CurrenceCrediting",
                column: "CurrenceCreditingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Creditings_Customer_CustomerId",
                table: "Creditings",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Creditings_CreditingId",
                table: "Payments",
                column: "CreditingId",
                principalTable: "Creditings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Customer_CustomerId",
                table: "Payments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionWithCustomers_CreditPrograms_CreditProgramId",
                table: "TransactionWithCustomers",
                column: "CreditProgramId",
                principalTable: "CreditPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionWithCustomers_Creditings_CreditingId",
                table: "TransactionWithCustomers",
                column: "CreditingId",
                principalTable: "Creditings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionWithCustomers_Customer_CustomerId",
                table: "TransactionWithCustomers",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
