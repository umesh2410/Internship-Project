using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksApi.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "Users");
        }
    }
}
