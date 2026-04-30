using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IsPasswordChanged = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluates",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluates", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_Evaluates_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evaluates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mentorings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollaboratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentorings_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mentorings_Users_CollaboratorId",
                        column: x => x.CollaboratorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mentorings_Users_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("37a5b39e-8c6c-4f7f-871d-6b5d9e5b5f5a"), "Langages et frameworks", "Développement" },
                    { new Guid("a2d8e4c1-4b1a-4d9a-9e1a-5f1e8a9d1c2b"), "Communication et leadership", "Soft Skills" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "HashedPassword", "IsActive", "IsPasswordChanged", "LastName", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jean@skillup.com", "Jean", "hash", true, false, "Mentor", 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"), new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice@skillup.com", "Alice", "hash", true, false, "Collab", 0, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"), new Guid("37a5b39e-8c6c-4f7f-871d-6b5d9e5b5f5a"), "", "C# / EF Core" },
                    { new Guid("c1d2e3f4-a5b6-4c7d-8e9f-0a1b2c3d4e5f"), new Guid("37a5b39e-8c6c-4f7f-871d-6b5d9e5b5f5a"), "", "SQL Server" }
                });

            migrationBuilder.InsertData(
                table: "Evaluates",
                columns: new[] { "SkillId", "UserId", "Comment", "LastUpdate", "Level" },
                values: new object[,]
                {
                    { new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"), new Guid("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b"), "", new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"), new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"), "", new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Mentorings",
                columns: new[] { "Id", "CollaboratorId", "CreatedAt", "MentorId", "SkillId", "Status" },
                values: new object[] { new Guid("1a2b3c4d-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"), new DateTime(2026, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1f2a3b4-c5d6-4e7f-8a9b-0c1d2e3f4a5b"), new Guid("b1c2d3e4-f5a6-4b7c-8d9e-0f1a2b3c4d5e"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluates_SkillId",
                table: "Evaluates",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentorings_CollaboratorId",
                table: "Mentorings",
                column: "CollaboratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentorings_MentorId",
                table: "Mentorings",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentorings_SkillId",
                table: "Mentorings",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CategoryId",
                table: "Skills",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluates");

            migrationBuilder.DropTable(
                name: "Mentorings");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
