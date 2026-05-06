using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkUrlToMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorita",
                table: "Musicas");

            migrationBuilder.AddColumn<string>(
                name: "LinkUrl",
                table: "Musicas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkUrl",
                table: "Musicas");

            migrationBuilder.AddColumn<bool>(
                name: "Favorita",
                table: "Musicas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
