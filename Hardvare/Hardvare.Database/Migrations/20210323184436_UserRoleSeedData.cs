using Microsoft.EntityFrameworkCore.Migrations;

namespace Hardvare.Database.Migrations
{
    public partial class UserRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { 2, "Customer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
