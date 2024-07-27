using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GazeteProje.Migrations
{
    public partial class pk11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentAndNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    CommentsCommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAndNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentAndNews_Comments_CommentsCommentId",
                        column: x => x.CommentsCommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK_CommentAndNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "NewsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentAndNews_CommentsCommentId",
                table: "CommentAndNews",
                column: "CommentsCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentAndNews_NewsId",
                table: "CommentAndNews",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentAndNews");
        }
    }
}
