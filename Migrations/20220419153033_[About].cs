using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SESEWebsite.Migrations
{
    public partial class About : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructors",
                newName: "SurName");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentsId",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Registers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProposedClass",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistredDate",
                table: "Registers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BIO",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistredDate",
                table: "Instructors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistredDate",
                table: "Enrollments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Creadits",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrollmentsId",
                table: "Students",
                column: "EnrollmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Enrollments_EnrollmentsId",
                table: "Students",
                column: "EnrollmentsId",
                principalTable: "Enrollments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Enrollments_EnrollmentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_EnrollmentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "ProposedClass",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "RegistredDate",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "BIO",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "FName",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "RegistredDate",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "RegistredDate",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Creadits",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Instructors",
                newName: "Name");
        }
    }
}
