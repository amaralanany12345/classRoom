using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassRoom.Migrations
{
    /// <inheritdoc />
    public partial class updateToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "invoked",
                table: "tokens",
                newName: "revoked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "revoked",
                table: "tokens",
                newName: "invoked");
        }
    }
}
