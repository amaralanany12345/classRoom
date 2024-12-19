using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.CreateTable(
                name: "classRoomStudents",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    classRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classRoomStudents", x => new { x.studentId, x.classRoomId });
                    table.ForeignKey(
                        name: "FK_classRoomStudents_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classRoomStudents_classRooms_classRoomId",
                        column: x => x.classRoomId,
                        principalTable: "classRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classRoomStudents_classRoomId",
                table: "classRoomStudents",
                column: "classRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classRoomStudents");

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
                name: "IX_ClassStudent_classRoomsid",
                table: "ClassStudent",
                column: "classRoomsid");
        }
    }
}
