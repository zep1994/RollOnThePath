using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RollOnThePath_API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_UserId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_UserId",
                table: "Lessons");

            // Remove the UserId column from the Lessons table
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lessons");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate the UserId column if the migration is rolled back
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lessons",
                type: "int",
                nullable: true);

            // Recreate the foreign key constraint and index for UserId
            migrationBuilder.CreateIndex(
                name: "IX_Lessons_UserId",
                table: "Lessons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_UserId",
                table: "Lessons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
