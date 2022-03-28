using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SESEWebsite.Data.Migrations
{
    public partial class register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Register");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Register",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
