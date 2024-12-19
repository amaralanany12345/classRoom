using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class studentAndInstructorToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.CreateTable(
                name: "instructorTokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    revoked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructorTokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_instructorTokens_Instructors_userId",
                        column: x => x.userId,
                        principalTable: "Instructors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentTokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    revoked = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentTokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_studentTokens_Students_userId",
                        column: x => x.userId,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_instructorTokens_userId",
                table: "instructorTokens",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_studentTokens_userId",
                table: "studentTokens",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "instructorTokens");

            migrationBuilder.DropTable(
                name: "studentTokens");

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    Instructorid = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_tokens_Instructors_Instructorid",
                        column: x => x.Instructorid,
                        principalTable: "Instructors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_tokens_Students_userId",
                        column: x => x.userId,
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tokens_Instructorid",
                table: "tokens",
                column: "Instructorid");

            migrationBuilder.CreateIndex(
                name: "IX_tokens_userId",
                table: "tokens",
                column: "userId");
        }
    }
}
