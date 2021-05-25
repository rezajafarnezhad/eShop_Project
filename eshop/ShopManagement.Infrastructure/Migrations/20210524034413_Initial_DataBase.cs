using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.Migrations
{
    public partial class Initial_DataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(233)", maxLength: 233, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(233)", maxLength: 233, nullable: false),
                    picture = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    pictureAlt = table.Column<string>(type: "nvarchar(233)", maxLength: 233, nullable: true),
                    pictureTitle = table.Column<string>(type: "nvarchar(233)", maxLength: 233, nullable: true),
                    KeyWords = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
