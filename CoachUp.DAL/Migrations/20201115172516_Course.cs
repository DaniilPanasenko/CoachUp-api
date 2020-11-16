using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Trainees_Trainee_Login",
                table: "Subscribes");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Coach_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Coaches_Coach_Login",
                        column: x => x.Coach_Login,
                        principalTable: "Coaches",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Coach_Login",
                table: "Courses",
                column: "Coach_Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Trainees_Trainee_Login",
                table: "Subscribes",
                column: "Trainee_Login",
                principalTable: "Trainees",
                principalColumn: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_Trainees_Trainee_Login",
                table: "Subscribes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_Trainees_Trainee_Login",
                table: "Subscribes",
                column: "Trainee_Login",
                principalTable: "Trainees",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
