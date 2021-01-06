using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class newColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMAGE_PATH",
                table: "SNACK",
                type: "VARCHAR(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IMAGE_PATH",
                table: "RESTAURANT",
                type: "VARCHAR(255)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMAGE_PATH",
                table: "SNACK");

            migrationBuilder.DropColumn(
                name: "IMAGE_PATH",
                table: "RESTAURANT");
        }
    }
}
