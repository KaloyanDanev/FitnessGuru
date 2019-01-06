using Microsoft.EntityFrameworkCore.Migrations;

namespace FitnessGuru.Data.Migrations
{
    public partial class ArticleDescriptionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleDescription",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleDescription",
                table: "Articles");
        }
    }
}
