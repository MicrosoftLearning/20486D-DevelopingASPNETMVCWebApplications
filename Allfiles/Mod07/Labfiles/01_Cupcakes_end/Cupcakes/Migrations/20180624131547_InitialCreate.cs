using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cupcakes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bakeries",
                columns: table => new
                {
                    BakeryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BakeryName = table.Column<string>(maxLength: 50, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bakeries", x => x.BakeryId);
                });

            migrationBuilder.CreateTable(
                name: "Cupcakes",
                columns: table => new
                {
                    CupcakeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CupcakeType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    GlutenFree = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    PhotoFile = table.Column<byte[]>(nullable: true),
                    ImageMimeType = table.Column<string>(nullable: true),
                    BakeryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupcakes", x => x.CupcakeId);
                    table.ForeignKey(
                        name: "FK_Cupcakes_Bakeries_BakeryId",
                        column: x => x.BakeryId,
                        principalTable: "Bakeries",
                        principalColumn: "BakeryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bakeries",
                columns: new[] { "BakeryId", "Address", "BakeryName", "Quantity" },
                values: new object[,]
                {
                    { 1, "635 Brighton Circle Road", "Gluteus Free", 8 },
                    { 2, "4323 Jerome Avenue", "Cupcakes Break", 22 },
                    { 3, "2553 Pin Oak Drive", "Cupcakes Ahead", 18 },
                    { 4, "1608 Charles Street", "Sugar", 30 }
                });

            migrationBuilder.InsertData(
                table: "Cupcakes",
                columns: new[] { "CupcakeId", "BakeryId", "CupcakeType", "Description", "GlutenFree", "ImageMimeType", "ImageName", "PhotoFile", "Price" },
                values: new object[,]
                {
                    { 1, 1, 0, "Vanilla cupcake with coconut cream", true, "image/jpeg", "birthday-cupcake.jpg", null, 2.5 },
                    { 2, 2, 2, "Chocolate cupcake with caramel filling and chocolate butter cream", false, "image/jpeg", "chocolate-cupcake.jpg", null, 3.2 },
                    { 3, 3, 3, "Chocolate cupcake with straberry cream filling", false, "image/jpeg", "pink-cupcake.jpg", null, 4.0 },
                    { 4, 4, 1, "Vanilla cupcake with butter cream", true, "image/jpeg", "turquoise-cupcake.jpg", null, 1.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cupcakes_BakeryId",
                table: "Cupcakes",
                column: "BakeryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cupcakes");

            migrationBuilder.DropTable(
                name: "Bakeries");
        }
    }
}
