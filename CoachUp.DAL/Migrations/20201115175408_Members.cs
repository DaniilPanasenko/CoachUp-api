using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class Members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Courses_Course_Id",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Trainees_Trainee_Login",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_Member_Trainee_Login",
                table: "Members",
                newName: "IX_Members_Trainee_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Member_Course_Id",
                table: "Members",
                newName: "IX_Members_Course_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Courses_Course_Id",
                table: "Members",
                column: "Course_Id",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Trainees_Trainee_Login",
                table: "Members",
                column: "Trainee_Login",
                principalTable: "Trainees",
                principalColumn: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Courses_Course_Id",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Trainees_Trainee_Login",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameIndex(
                name: "IX_Members_Trainee_Login",
                table: "Member",
                newName: "IX_Member_Trainee_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Members_Course_Id",
                table: "Member",
                newName: "IX_Member_Course_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Courses_Course_Id",
                table: "Member",
                column: "Course_Id",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Trainees_Trainee_Login",
                table: "Member",
                column: "Trainee_Login",
                principalTable: "Trainees",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
