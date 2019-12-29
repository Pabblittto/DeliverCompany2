using Microsoft.EntityFrameworkCore.Migrations;

namespace DazyBanychMVC.Migrations
{
    public partial class carpatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VIN",
                table: "Cars",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "VIN",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 17);
        }
    }
}
