using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Trainees_Trainee1_Login",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Trainees_Trainee2_Login",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "Trainee2_Login",
                table: "Friends",
                newName: "TraineeTwo_Login");

            migrationBuilder.RenameColumn(
                name: "Trainee1_Login",
                table: "Friends",
                newName: "TraineeOne_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_Trainee2_Login",
                table: "Friends",
                newName: "IX_Friends_TraineeTwo_Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Trainees_TraineeOne_Login",
                table: "Friends",
                column: "TraineeOne_Login",
                principalTable: "Trainees",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Trainees_TraineeTwo_Login",
                table: "Friends",
                column: "TraineeTwo_Login",
                principalTable: "Trainees",
                principalColumn: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Trainees_TraineeOne_Login",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_Trainees_TraineeTwo_Login",
                table: "Friends");

            migrationBuilder.RenameColumn(
                name: "TraineeTwo_Login",
                table: "Friends",
                newName: "Trainee2_Login");

            migrationBuilder.RenameColumn(
                name: "TraineeOne_Login",
                table: "Friends",
                newName: "Trainee1_Login");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_TraineeTwo_Login",
                table: "Friends",
                newName: "IX_Friends_Trainee2_Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Trainees_Trainee1_Login",
                table: "Friends",
                column: "Trainee1_Login",
                principalTable: "Trainees",
                principalColumn: "Login");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_Trainees_Trainee2_Login",
                table: "Friends",
                column: "Trainee2_Login",
                principalTable: "Trainees",
                principalColumn: "Login");
        }
    }
}
