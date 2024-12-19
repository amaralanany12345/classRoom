using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class tokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions");

            migrationBuilder.CreateTable(
                name: "tokens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    invoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Instructorid = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions",
                column: "fileId",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions");

            migrationBuilder.DropTable(
                name: "tokens");

            migrationBuilder.AddForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions",
                column: "fileId",
                principalTable: "files",
                principalColumn: "id");
        }
    }
}
