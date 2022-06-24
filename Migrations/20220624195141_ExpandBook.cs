using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLibraryManager.Migrations
{
    public partial class ExpandBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books",
                newName: "PublishedDate");

            migrationBuilder.AddColumn<string>(
                name: "Authors",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EditionNotes",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFirstEdition",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PageCount",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrintNumber",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Authors",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EditionNotes",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsFirstEdition",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PageCount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PrintNumber",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PublishedDate",
                table: "Books",
                newName: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
