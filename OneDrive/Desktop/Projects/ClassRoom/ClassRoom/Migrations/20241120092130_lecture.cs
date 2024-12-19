using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class lecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lectures",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classRoomId = table.Column<int>(type: "int", nullable: false),
                    lectureFileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lectures", x => x.id);
                    table.ForeignKey(
                        name: "FK_lectures_classRooms_classRoomId",
                        column: x => x.classRoomId,
                        principalTable: "classRooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lectures_files_lectureFileId",
                        column: x => x.lectureFileId,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lectures_classRoomId",
                table: "lectures",
                column: "classRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_lectures_lectureFileId",
                table: "lectures",
                column: "lectureFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lectures");
        }
    }
}
