using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDemo.Api.Migrations
{
    public partial class AddTickers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMarket",
                table: "EndOfDays");

            migrationBuilder.CreateTable(
                name: "Tickers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    StockIdentifierCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickers");

            migrationBuilder.AddColumn<string>(
                name: "StockMarket",
                table: "EndOfDays",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
