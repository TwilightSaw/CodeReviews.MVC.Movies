using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.TwilightSaw.Migrations
{
    /// <inheritdoc />
    public partial class Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Series",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");
        }
    }
}
