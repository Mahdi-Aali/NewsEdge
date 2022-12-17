using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsEdge.Web.Migrations
{
    public partial class AddingSomeEditToNewsInSectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsInSections_NewsSections_NewsSectionId",
                table: "NewsInSections");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "NewsInSections");

            migrationBuilder.AlterColumn<long>(
                name: "NewsSectionId",
                table: "NewsInSections",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsInSections_NewsSections_NewsSectionId",
                table: "NewsInSections",
                column: "NewsSectionId",
                principalTable: "NewsSections",
                principalColumn: "NewsSectionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsInSections_NewsSections_NewsSectionId",
                table: "NewsInSections");

            migrationBuilder.AlterColumn<long>(
                name: "NewsSectionId",
                table: "NewsInSections",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "SectionId",
                table: "NewsInSections",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsInSections_NewsSections_NewsSectionId",
                table: "NewsInSections",
                column: "NewsSectionId",
                principalTable: "NewsSections",
                principalColumn: "NewsSectionId");
        }
    }
}
