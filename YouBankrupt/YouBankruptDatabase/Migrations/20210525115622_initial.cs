using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouBankruptDatabaseImplements.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creditings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Sum = table.Column<int>(nullable: false),
                    DateCredit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
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
                    table.PrimaryKey("PK_Customers", x => x.Id);
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
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Sum = table.Column<int>(nullable: false),
                    DatePayment = table.Column<DateTime>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "CreditPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: true),
                    CreditProgramName = table.Column<string>(nullable: false),
                    Persent = table.Column<double>(nullable: false),
                    PaymentTerm = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditPrograms_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: true),
                    CurrenceName = table.Column<string>(nullable: false),
                    Rate = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currences_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesCurrences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(nullable: true),
                    PurchasesName = table.Column<string>(nullable: false),
                    DateBuy = table.Column<DateTime>(nullable: false)
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
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CreditProgramId = table.Column<int>(nullable: true),
                    CreditingId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_CreditPrograms_CreditProgramId",
                        column: x => x.CreditProgramId,
                        principalTable: "CreditPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Creditings_CreditingId",
                        column: x => x.CreditingId,
                        principalTable: "Creditings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_CreditingCurrence_CreditingId",
                table: "CreditingCurrence",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditingCurrence_CurrenceId",
                table: "CreditingCurrence",
                column: "CurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProgramCurrences_CreditProgramId",
                table: "CreditProgramCurrences",
                column: "CreditProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProgramCurrences_CurrenceId",
                table: "CreditProgramCurrences",
                column: "CurrenceId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditPrograms_SupplierId",
                table: "CreditPrograms",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Currences_SupplierId",
                table: "Currences",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreditingId",
                table: "Payments",
                column: "CreditingId");

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
                name: "IX_Transactions_CreditProgramId",
                table: "Transactions",
                column: "CreditProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreditingId",
                table: "Transactions",
                column: "CreditingId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerId",
                table: "Transactions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditingCurrence");

            migrationBuilder.DropTable(
                name: "CreditProgramCurrences");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PurchasesCurrenceCurrences");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Currences");

            migrationBuilder.DropTable(
                name: "PurchasesCurrences");

            migrationBuilder.DropTable(
                name: "CreditPrograms");

            migrationBuilder.DropTable(
                name: "Creditings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
