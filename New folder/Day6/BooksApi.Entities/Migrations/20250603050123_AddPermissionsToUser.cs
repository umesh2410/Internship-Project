using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksApi.Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permission",
                table: "Users",
                newName: "Permissions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "Users",
                newName: "Permission");
        }
    }
}
