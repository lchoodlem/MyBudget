using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBudgetYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentYear",
                table: "BudgetYears",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "BudgetYears",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentYear",
                table: "BudgetYears");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "BudgetYears");
        }
    }
}
