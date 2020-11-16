using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class MediaMotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Box_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medias_Boxes_Box_ID",
                        column: x => x.Box_ID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Box_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motions_Boxes_Box_ID",
                        column: x => x.Box_ID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_Box_ID",
                table: "Medias",
                column: "Box_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Motions_Box_ID",
                table: "Motions",
                column: "Box_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Motions");
        }
    }
}
