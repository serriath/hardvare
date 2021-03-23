using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hardvare.Database.Migrations
{
    public partial class AddPasswordWithSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "User");
        }
    }
}
