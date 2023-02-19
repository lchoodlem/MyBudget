using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Server.Migrations
{
    /// <inheritdoc />
    public partial class BudgetYearTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetYears_ReconcileBalances_ReconcileBalanceId",
                table: "BudgetYears");

            migrationBuilder.AlterColumn<int>(
                name: "ReconcileBalanceId",
                table: "BudgetYears",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetYears_ReconcileBalances_ReconcileBalanceId",
                table: "BudgetYears",
                column: "ReconcileBalanceId",
                principalTable: "ReconcileBalances",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetYears_ReconcileBalances_ReconcileBalanceId",
                table: "BudgetYears");

            migrationBuilder.AlterColumn<int>(
                name: "ReconcileBalanceId",
                table: "BudgetYears",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetYears_ReconcileBalances_ReconcileBalanceId",
                table: "BudgetYears",
                column: "ReconcileBalanceId",
                principalTable: "ReconcileBalances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
