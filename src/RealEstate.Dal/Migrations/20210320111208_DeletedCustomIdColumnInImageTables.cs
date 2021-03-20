using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.Dal.Migrations
{
    public partial class DeletedCustomIdColumnInImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomId",
                table: "static_image");

            migrationBuilder.DropColumn(
                name: "CustomId",
                table: "panoramic_image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomId",
                table: "static_image",
                type: "varchar(30) CHARACTER SET utf8mb4",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomId",
                table: "panoramic_image",
                type: "varchar(30) CHARACTER SET utf8mb4",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
