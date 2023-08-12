using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Blogmodelchanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Blog");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Blog",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Recipe");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Recipe",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");
        }
    }
}
