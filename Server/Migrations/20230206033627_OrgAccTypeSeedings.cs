using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBudget.Server.Migrations
{
    /// <inheritdoc />
    public partial class OrgAccTypeSeedings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcctTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcctTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AcctTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Visa" },
                    { 2, "MC" },
                    { 3, "Loan" },
                    { 4, "Bank" }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address1", "Address2", "Description", "Name", "Phone1", "Phone2" },
                values: new object[,]
                {
                    { 1, "", "", "", "Chase", "", "" },
                    { 2, "", "", "", "PNC", "", "" },
                    { 3, "", "", "", "Cabellas", "", "" },
                    { 4, "", "", "", "MLife", "", "" },
                    { 5, "", "", "", "Xfinity", "", "" },
                    { 6, "", "", "", "BestBuy", "", "" },
                    { 7, "", "", "", "Best Egg", "", "" },
                    { 8, "", "", "", "NetFlix", "", "" },
                    { 9, "", "", "", "Green Mountain", "", "" },
                    { 10, "", "", "", "Chesapeake", "", "" },
                    { 11, "", "", "", "Progressive", "", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcctTypes");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
