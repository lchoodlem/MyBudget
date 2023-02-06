using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBudget.Server.Migrations
{
    /// <inheritdoc />
    public partial class TransTypeSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Debit", "Description", "TypeName" },
                values: new object[,]
                {
                    { 1, false, "This is a Deposit Transation (+)", "Deposit" },
                    { 2, true, "This is a Paymenmt Transation (-)", "Payment" },
                    { 3, true, "This is a Withdrawl Payment Transation (-)", "CashWithdrawl" },
                    { 4, false, "This is a Withdrawl Transation (+)", "CashDep" },
                    { 5, true, "This is a Credit Card Paymenmt Transation (-)", "CCPayment" },
                    { 6, false, "This is a Salary Transation (+)", "Payroll" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
