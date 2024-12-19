using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "classRooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    instructorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classRooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_classRooms_Instructors_instructorId",
                        column: x => x.instructorId,
                        principalTable: "Instructors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    Studentsid = table.Column<int>(type: "int", nullable: false),
                    classRoomsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.Studentsid, x.classRoomsid });
                    table.ForeignKey(
                        name: "FK_ClassStudent_Students_Studentsid",
                        column: x => x.Studentsid,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_classRooms_classRoomsid",
                        column: x => x.classRoomsid,
                        principalTable: "classRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classRooms_instructorId",
                table: "classRooms",
                column: "instructorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_classRoomsid",
                table: "ClassStudent",
                column: "classRoomsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "classRooms");

            migrationBuilder.DropTable(
                name: "Instructors");
        }
    }
}
