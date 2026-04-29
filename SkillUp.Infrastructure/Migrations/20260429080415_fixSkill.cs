using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"),
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-4c7d-8e9f-0a1b2c3d4e5f"),
                column: "Description",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-4c7d-8e9f-0a1b2c3d4e5f"),
                column: "Description",
                value: "");
        }
    }
}
