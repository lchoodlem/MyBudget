using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBudget.Server.Migrations
{
    /// <inheritdoc />
    public partial class Accounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcctNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcctTypeId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctTypes_AcctTypeId",
                        column: x => x.AcctTypeId,
                        principalTable: "AcctTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AcctNum", "AcctTypeId", "Name", "OrganizationId" },
                values: new object[,]
                {
                    { 1, "...0000", 3, "Egg1", 7 },
                    { 2, "...0000", 3, "Egg2", 7 },
                    { 3, "...0000", 3, "Bronco", 2 },
                    { 4, "...0000", 3, "Harley", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AcctTypeId",
                table: "Accounts",
                column: "AcctTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OrganizationId",
                table: "Accounts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
