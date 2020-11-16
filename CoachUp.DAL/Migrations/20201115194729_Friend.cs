using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class Friend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Trainee1_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Trainee2_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.Trainee1_Login, x.Trainee2_Login });
                    table.ForeignKey(
                        name: "FK_Friends_Trainees_Trainee1_Login",
                        column: x => x.Trainee1_Login,
                        principalTable: "Trainees",
                        principalColumn: "Login");
                    table.ForeignKey(
                        name: "FK_Friends_Trainees_Trainee2_Login",
                        column: x => x.Trainee2_Login,
                        principalTable: "Trainees",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_Trainee2_Login",
                table: "Friends",
                column: "Trainee2_Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");
        }
    }
}
