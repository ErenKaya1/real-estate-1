using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Dal.Migrations
{
    public partial class ChangedSortColumnInImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "static_image");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "panoramic_image");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "static_image",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "panoramic_image",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "static_image");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "panoramic_image");

            migrationBuilder.AddColumn<string>(
                name: "Sort",
                table: "static_image",
                type: "varchar(3) CHARACTER SET utf8mb4",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sort",
                table: "panoramic_image",
                type: "varchar(3) CHARACTER SET utf8mb4",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
