using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class a3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_Courses_course_courseid",
                table: "teacher_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_Courses_teachers_teacherid",
                table: "teacher_Courses");

            migrationBuilder.RenameColumn(
                name: "teacherid",
                table: "teacher_Courses",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "courseid",
                table: "teacher_Courses",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_Courses_teacherid",
                table: "teacher_Courses",
                newName: "IX_teacher_Courses_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_Courses_courseid",
                table: "teacher_Courses",
                newName: "IX_teacher_Courses_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_Courses_course_CourseId",
                table: "teacher_Courses",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_Courses_teachers_TeacherId",
                table: "teacher_Courses",
                column: "TeacherId",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teacher_Courses_course_CourseId",
                table: "teacher_Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_teacher_Courses_teachers_TeacherId",
                table: "teacher_Courses");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "teacher_Courses",
                newName: "teacherid");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "teacher_Courses",
                newName: "courseid");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_Courses_TeacherId",
                table: "teacher_Courses",
                newName: "IX_teacher_Courses_teacherid");

            migrationBuilder.RenameIndex(
                name: "IX_teacher_Courses_CourseId",
                table: "teacher_Courses",
                newName: "IX_teacher_Courses_courseid");

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_Courses_course_courseid",
                table: "teacher_Courses",
                column: "courseid",
                principalTable: "course",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_teacher_Courses_teachers_teacherid",
                table: "teacher_Courses",
                column: "teacherid",
                principalTable: "teachers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
