using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApp.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "0987654321", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Number", "Owner" },
                values: new object[] { "1234567890", "John Doe" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "BankAccountId", "Date", "Note" },
                values: new object[,]
                {
                    { 1, 200.00m, "1234567890", new DateTime(2021, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Deposito inicial" },
                    { 2, 300.00m, "1234567890", new DateTime(2021, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), "Deposito" },
                    { 3, -150.00m, "1234567890", new DateTime(2021, 1, 3, 9, 30, 0, 0, DateTimeKind.Unspecified), "Retiro" },
                    { 4, 400.00m, "0987654321", new DateTime(2021, 1, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), "Deposito" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccountId",
                table: "Transactions",
                column: "BankAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
