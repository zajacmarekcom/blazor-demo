using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDemo.Api.Migrations
{
    public partial class CurrencyInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency_Code",
                table: "StockMarkets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currency_Name",
                table: "StockMarkets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency_Code",
                table: "StockMarkets");

            migrationBuilder.DropColumn(
                name: "Currency_Name",
                table: "StockMarkets");
        }
    }
}
