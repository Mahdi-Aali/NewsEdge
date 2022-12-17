using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsEdge.Web.Migrations
{
    public partial class AddingNewsInSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsInSections",
                columns: table => new
                {
                    NewsInSectionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<long>(type: "bigint", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false),
                    NewsSectionId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsInSections", x => x.NewsInSectionId);
                    table.ForeignKey(
                        name: "FK_NewsInSections_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsInSections_NewsSections_NewsSectionId",
                        column: x => x.NewsSectionId,
                        principalTable: "NewsSections",
                        principalColumn: "NewsSectionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsInSections_NewsId",
                table: "NewsInSections",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsInSections_NewsSectionId",
                table: "NewsInSections",
                column: "NewsSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsInSections");
        }
    }
}
