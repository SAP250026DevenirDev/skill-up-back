using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b"),
                column: "HashedPassword",
                value: "Y92gmIIn9/HsivTyLtWMY509RVjeMI1jCH8VdBkt8QVPWOfgbH0bMcJANnCXB0GK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"),
                column: "HashedPassword",
                value: "/W9gBsPa8we2uFArQsCyjvmeIE3LiiryE9biTMx7/JWg/cOYl6yajUsnrjWzAc9U");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "HashedPassword", "IsActive", "IsPasswordChanged", "LastName", "Role", "UpdatedAt" },
                values: new object[] { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@skillup.com", "Admin", "YqpWnU8TuQ9Mkma000ZRdiIjwehAbBwf5+qt+TvaiLoGV9c4ktppxkVG82dNKs/q", true, false, "SkillUp", 2, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b"),
                column: "HashedPassword",
                value: "hash");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"),
                column: "HashedPassword",
                value: "hash");
        }
    }
}
