using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreateInk.Migrations
{
    public partial class AddedPasswordAndEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Artists",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Artists",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Artists",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }
        //TODO update database to have data in extra fields
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Artists");
        }
    }
}
