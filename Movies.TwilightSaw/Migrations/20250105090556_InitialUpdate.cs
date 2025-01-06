using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movies.TwilightSaw.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EpisodeNumber",
                table: "Series",
                newName: "Episodes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Episodes",
                table: "Series",
                newName: "EpisodeNumber");
        }
    }
}
