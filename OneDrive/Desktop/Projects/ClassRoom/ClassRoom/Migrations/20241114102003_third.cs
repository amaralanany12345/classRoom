using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "classRooms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    classRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Assignment_classRooms_classRoomId",
                        column: x => x.classRoomId,
                        principalTable: "classRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filePath = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "submissions",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    assignmentId = table.Column<int>(type: "int", nullable: false),
                    studentScore = table.Column<int>(type: "int", nullable: false),
                    fileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submissions", x => new { x.studentId, x.assignmentId });
                    table.ForeignKey(
                        name: "FK_submissions_Assignment_assignmentId",
                        column: x => x.assignmentId,
                        principalTable: "Assignment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_submissions_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_submissions_files_fileId",
                        column: x => x.fileId,
                        principalTable: "files",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_classRooms_code",
                table: "classRooms",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_classRoomId",
                table: "Assignment",
                column: "classRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_submissions_assignmentId",
                table: "submissions",
                column: "assignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_submissions_fileId",
                table: "submissions",
                column: "fileId",
                unique: true,
                filter: "[fileId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "submissions");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropIndex(
                name: "IX_classRooms_code",
                table: "classRooms");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                table: "classRooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
