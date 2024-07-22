using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class a2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    totaltime = table.Column<float>(type: "real", nullable: false),
                    descript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    videointro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "course_detailfile",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descript = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_detailfile", x => x.id);
                    table.ForeignKey(
                        name: "FK_course_detailfile_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teacher_Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacherid = table.Column<int>(type: "int", nullable: false),
                    courseid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher_Courses", x => x.id);
                    table.ForeignKey(
                        name: "FK_teacher_Courses_course_courseid",
                        column: x => x.courseid,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teacher_Courses_teachers_teacherid",
                        column: x => x.teacherid,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_detailfile_courseid",
                table: "course_detailfile",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_Courses_courseid",
                table: "teacher_Courses",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_teacher_Courses_teacherid",
                table: "teacher_Courses",
                column: "teacherid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_detailfile");

            migrationBuilder.DropTable(
                name: "teacher_Courses");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
