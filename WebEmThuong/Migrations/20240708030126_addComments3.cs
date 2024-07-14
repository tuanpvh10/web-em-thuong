using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEmThuong.Migrations
{
    /// <inheritdoc />
    public partial class addComments3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Comments",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Comments",
                newName: "NameUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Comments",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "NameUser",
                table: "Comments",
                newName: "Name");
        }
    }
}
