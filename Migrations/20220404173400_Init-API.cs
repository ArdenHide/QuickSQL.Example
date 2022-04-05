using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversalAPI.Example.Migrations
{
    public partial class InitAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APIRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedTables = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinCondition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APIRequests", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "APIRequests",
                columns: new[] { "Id", "JoinCondition", "Name", "SelectedColumns", "SelectedTables" },
                values: new object[] { 1, "SignUp.Address = LeaderBoard.Owner", "mysignup", "SignUp.PoolId, LeaderBoard.Rank, LeaderBoard.Owner, LeaderBoard.Amount", "SignUp, LeaderBoard" });

            migrationBuilder.InsertData(
                table: "APIRequests",
                columns: new[] { "Id", "JoinCondition", "Name", "SelectedColumns", "SelectedTables" },
                values: new object[] { 2, null, "wallet", "*", "Wallets" });

            migrationBuilder.InsertData(
                table: "APIRequests",
                columns: new[] { "Id", "JoinCondition", "Name", "SelectedColumns", "SelectedTables" },
                values: new object[] { 3, null, "tokenbalanse", "Token, Owner, Amount", "TokenBalances" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APIRequests");
        }
    }
}
