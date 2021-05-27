using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.Migrations
{
    public partial class ProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UnitPrice = table.Column<double>(type: "float", maxLength: 200, nullable: false),
                    IsinStocke = table.Column<bool>(type: "bit", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(560)", maxLength: 560, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    picture = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    pictureAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pictureTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KeyWords = table.Column<string>(type: "nvarchar(555)", maxLength: 555, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(655)", maxLength: 655, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(455)", maxLength: 455, nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
