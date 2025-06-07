using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mission.Entities.Migrations
{
    /// <inheritdoc />
    public partial class NewDataInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "first_name", "last_name", "password", "phone_number" },
                values: new object[] { "Tirthadmin@gmail.com.com", "Tirth", "Patel", "T@123", "9676543210" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "email_address", "first_name", "last_name", "password", "phone_number" },
                values: new object[] { "admin@tatvasoft.com", "Tatva", "Admin", "admin", "9876543210" });
        }
    }
}
