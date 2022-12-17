using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsEdge.Web.Migrations
{
    public partial class Editing_AuthorRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorRequest_AspNetUsers_UserId",
                table: "AuthorRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorRequest",
                table: "AuthorRequest");

            migrationBuilder.RenameTable(
                name: "AuthorRequest",
                newName: "AuthorRequests");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorRequest_UserId",
                table: "AuthorRequests",
                newName: "IX_AuthorRequests_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorRequests",
                table: "AuthorRequests",
                column: "AuthorRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorRequests_AspNetUsers_UserId",
                table: "AuthorRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorRequests_AspNetUsers_UserId",
                table: "AuthorRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorRequests",
                table: "AuthorRequests");

            migrationBuilder.RenameTable(
                name: "AuthorRequests",
                newName: "AuthorRequest");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorRequests_UserId",
                table: "AuthorRequest",
                newName: "IX_AuthorRequest_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorRequest",
                table: "AuthorRequest",
                column: "AuthorRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorRequest_AspNetUsers_UserId",
                table: "AuthorRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
