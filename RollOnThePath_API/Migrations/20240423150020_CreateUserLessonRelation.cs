using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RollOnThePath_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserLessonRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Lessons_LessonsId",
                table: "UserLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Users_UsersId",
                table: "UserLessons");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserLessons",
                newName: "LessonId");

            migrationBuilder.RenameColumn(
                name: "LessonsId",
                table: "UserLessons",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessons_UsersId",
                table: "UserLessons",
                newName: "IX_UserLessons_LessonId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Lessons",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_UserId",
                table: "Lessons",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Users_UserId",
                table: "Lessons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Lessons_LessonId",
                table: "UserLessons",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Users_UserId",
                table: "UserLessons",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Users_UserId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Lessons_LessonId",
                table: "UserLessons");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLessons_Users_UserId",
                table: "UserLessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_UserId",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "UserLessons",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserLessons",
                newName: "LessonsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLessons_LessonId",
                table: "UserLessons",
                newName: "IX_UserLessons_UsersId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Lessons_LessonsId",
                table: "UserLessons",
                column: "LessonsId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLessons_Users_UsersId",
                table: "UserLessons",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
