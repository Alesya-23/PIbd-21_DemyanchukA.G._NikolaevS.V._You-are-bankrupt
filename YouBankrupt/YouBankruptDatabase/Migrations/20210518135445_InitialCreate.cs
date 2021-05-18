using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditProgramName = table.Column<string>(nullable: false),
                    Persent = table.Column<double>(nullable: false),
                    PaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrenceName = table.Column<string>(nullable: false),
                    Rate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierFullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditProgramCurrences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditProgramId = table.Column<int>(nullable: false),
                    CurrenceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProgramCurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditProgramCurrences_CreditPrograms_CreditProgramId",
                        column: x => x.CreditProgramId,
                        principalTable: "CreditPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditProgramCurrences_Currences_CurrenceId",
                        column: x => x.CurrenceId,
                        principalTable: "Currences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creditings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creditings_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesCurrences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasesName = table.Column<string>(nullable: false),
                    DateBuy = table.Column<DateTime>(nullable: false),
                    Summ = table.Column<double>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesCurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesCurrences_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<int>(nullable: false),
                    DatePayment = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CreditingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Creditings_CreditingId",
                        column: x => x.CreditingId,
                        principalTable: "Creditings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionWithCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CreditingProgramId = table.Column<int>(nullable: false),
                    CreditProgramId = table.Column<int>(nullable: true),
                    CreditingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionWithCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionWithCustomers_CreditPrograms_CreditProgramId",
                        column: x => x.CreditProgramId,
                        principalTable: "CreditPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionWithCustomers_Creditings_CreditingId",
                        column: x => x.CreditingId,
                        principalTable: "Creditings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionWithCustomers_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesCurrenceCurrences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasesCurrenceId = table.Column<int>(nullable: false),
                    CurrenceId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    PurchasesCurrenseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesCurrenceCurrences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesCurrenceCurrences_Currences_CurrenceId",
                        column: x => x.CurrenceId,
                        principalTable: "Currences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesCurrenceCurrences_PurchasesCurrences_PurchasesCurrenseId",
                        column: x => x.PurchasesCurrenseId,
                        principalTable: "PurchasesCurrences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Creditings_CustomerId",
                table: "Creditings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProgramCurrences_CreditProgramId",
                table: "CreditProgramCurrences",
                column: "CreditProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProgramCurrences_CurrenceId",
                table: "CreditProgramCurrences",
                column: "CurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreditingId",
                table: "Payments",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesCurrenceCurrences_CurrenceId",
                table: "PurchasesCurrenceCurrences",
                column: "CurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesCurrenceCurrences_PurchasesCurrenseId",
                table: "PurchasesCurrenceCurrences",
                column: "PurchasesCurrenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesCurrences_SupplierId",
                table: "PurchasesCurrences",
                column: "SupplierId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditProgramCurrences");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PurchasesCurrenceCurrences");

            migrationBuilder.DropTable(
                name: "TransactionWithCustomers");

            migrationBuilder.DropTable(
                name: "Currences");

            migrationBuilder.DropTable(
                name: "PurchasesCurrences");

            migrationBuilder.DropTable(
                name: "CreditPrograms");

            migrationBuilder.DropTable(
                name: "Creditings");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
