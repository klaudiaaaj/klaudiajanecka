using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class CreateOrcid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First = table.Column<string>(nullable: false),
                    Last = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcid", x => x.Id);
                });

            migrationBuilder.AddColumn<string>(
                name: "OrcId",
                table: "Orcid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orcid_OrcId",
                table: "Orcid",
                column: "OrcId",
                unique: true,
                filter: "[OrcId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orcid_OrcId",
                table: "Orcid");

            migrationBuilder.DropColumn(
                name: "OrcId",
                table: "Orcid");

            migrationBuilder.DropTable(
               name: "Orcid");
        }
    }
}
