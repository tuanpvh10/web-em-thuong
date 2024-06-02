using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEmThuong.Migrations
{
    /// <inheritdoc />
    public partial class SortForProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "Productions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "Productions");
        }
    }
}
