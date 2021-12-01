using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovieDBApp.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SearchData",
                table: "SearchHistory",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchData",
                table: "SearchHistory");
        }
    }
}
