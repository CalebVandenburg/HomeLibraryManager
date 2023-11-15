using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLibraryManager.Migrations
{
    public partial class ShelfFormatToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShelfFormatAsCard",
                table: "Users",
                newName: "ShelfFormat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShelfFormat",
                table: "Users",
                newName: "ShelfFormatAsCard");
        }
    }
}
