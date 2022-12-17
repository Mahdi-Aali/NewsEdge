using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsEdge.Web.Migrations
{
    public partial class EditingNewsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YouTubeLink",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YouTubeLink",
                table: "News");
        }
    }
}
