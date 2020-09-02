using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDemo.Api.Migrations
{
    public partial class ChangeCountryCodeToCountryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "StockMarkets");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "StockMarkets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "StockMarkets");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "StockMarkets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
