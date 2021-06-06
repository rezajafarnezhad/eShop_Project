using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Infrastructure.Migrations
{
    public partial class UpdateMappingProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "nvarchar(2400)",
                maxLength: 2400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(560)",
                oldMaxLength: 560,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(455)",
                maxLength: 455,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Products",
                type: "nvarchar(2400)",
                maxLength: 2400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(655)",
                oldMaxLength: 655);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Products",
                type: "nvarchar(560)",
                maxLength: 560,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2400)",
                oldMaxLength: 2400,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(455)",
                oldMaxLength: 455);

            migrationBuilder.AlterColumn<string>(
                name: "MetaDescription",
                table: "Products",
                type: "nvarchar(655)",
                maxLength: 655,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2400)",
                oldMaxLength: 2400);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
