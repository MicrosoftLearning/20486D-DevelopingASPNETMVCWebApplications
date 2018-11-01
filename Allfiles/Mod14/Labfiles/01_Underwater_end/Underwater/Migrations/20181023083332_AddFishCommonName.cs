using Microsoft.EntityFrameworkCore.Migrations;

namespace Underwater.Migrations
{
    public partial class AddFishCommonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FishType",
                table: "fishes",
                newName: "CommonName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommonName",
                table: "fishes",
                newName: "FishType");
        }
    }
}
