using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hardvare.Database.Migrations
{
    public partial class RemovePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "User",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
