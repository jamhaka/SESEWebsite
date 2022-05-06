using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SESEWebsite.Migrations
{
    public partial class convert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoInByte",
                table: "Registers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoInByte",
                table: "Registers");
        }
    }
}
