using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.Migrations
{
    public partial class Slides_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    PictureAlt = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    PictureTitle = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: true),
                    btnText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");
        }
    }
}
