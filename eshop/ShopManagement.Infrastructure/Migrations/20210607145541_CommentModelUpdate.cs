using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.Migrations
{
    public partial class CommentModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isconfirm",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "Isconfirm",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
