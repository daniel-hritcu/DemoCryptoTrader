using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCryptoTrader.EntityFramework.Migrations
{
    public partial class correct_asset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coin_Symbol",
                table: "CoinTransactions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Coin_Symbol",
                table: "CoinTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
