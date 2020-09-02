using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorDemo.Api.Migrations
{
    public partial class ChangeVolumeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Volume",
                table: "EndOfDays",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "EndOfDays",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
