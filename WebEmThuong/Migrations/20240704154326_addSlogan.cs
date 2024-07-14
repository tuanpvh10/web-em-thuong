using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEmThuong.Migrations
{
    /// <inheritdoc />
    public partial class addSlogan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "BackGround",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "BackGround");
        }
    }
}
