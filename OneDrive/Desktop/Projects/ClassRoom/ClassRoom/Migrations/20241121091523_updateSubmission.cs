using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class updateSubmission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions");

            migrationBuilder.DropIndex(
                name: "IX_submissions_fileId",
                table: "submissions");

            migrationBuilder.AlterColumn<int>(
                name: "fileId",
                table: "submissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_submissions_fileId",
                table: "submissions",
                column: "fileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions",
                column: "fileId",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions");

            migrationBuilder.DropIndex(
                name: "IX_submissions_fileId",
                table: "submissions");

            migrationBuilder.AlterColumn<int>(
                name: "fileId",
                table: "submissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_submissions_fileId",
                table: "submissions",
                column: "fileId",
                unique: true,
                filter: "[fileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_submissions_files_fileId",
                table: "submissions",
                column: "fileId",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
