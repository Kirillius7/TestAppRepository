using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    idCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameCourse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    teacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mark = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.idCourse);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    idStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.idStudent);
                });

            migrationBuilder.CreateTable(
                name: "studentsCourses",
                columns: table => new
                {
                    sc_idS = table.Column<int>(type: "int", nullable: false),
                    sc_idC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentsCourses", x => new { x.sc_idC, x.sc_idS });
                    table.ForeignKey(
                        name: "FK_studentsCourses_courses_sc_idC",
                        column: x => x.sc_idC,
                        principalTable: "courses",
                        principalColumn: "idCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentsCourses_students_sc_idS",
                        column: x => x.sc_idS,
                        principalTable: "students",
                        principalColumn: "idStudent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentsCourses_sc_idS",
                table: "studentsCourses",
                column: "sc_idS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentsCourses");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
