using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class AddReviewersToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleReviewer",
                columns: table => new
                {
                    ReviewerId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleReviewer", x => new { x.ReviewerId, x.ArticleId });
                    table.ForeignKey(
                        name: "FK_ArticleReviewer_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleReviewer_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReviewer_ArticleId",
                table: "ArticleReviewer",
                column: "ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleReviewer");
        }
    }
}
