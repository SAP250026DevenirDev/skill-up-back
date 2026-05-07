using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillUp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fixmentoringconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentorings_Users_CollaboratorId",
                table: "Mentorings");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentorings_Users_CollaboratorId",
                table: "Mentorings",
                column: "CollaboratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mentorings_Users_CollaboratorId",
                table: "Mentorings");

            migrationBuilder.AddForeignKey(
                name: "FK_Mentorings_Users_CollaboratorId",
                table: "Mentorings",
                column: "CollaboratorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
