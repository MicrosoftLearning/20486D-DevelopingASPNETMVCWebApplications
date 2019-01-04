using Microsoft.EntityFrameworkCore.Migrations;

namespace Underwater.Migrations
{
    public partial class AddFishCommonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                table: "fishes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommonName",
                table: "fishes");
        }
    }
}
