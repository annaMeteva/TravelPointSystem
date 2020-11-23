using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPointSystem.Data.Migrations
{
    public partial class UpdateDestinationDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Flag",
                table: "Destinations");

            migrationBuilder.AlterColumn<string>(
                name: "Town",
                table: "Destinations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Town",
                table: "Destinations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Flag",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
