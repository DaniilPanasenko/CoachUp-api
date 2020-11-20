using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class T : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_CourseComments_Reply_Comment_ID",
                table: "CourseComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingComments_TrainingComments_Reply_Comment_ID",
                table: "TrainingComments");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_CourseComments_Reply_Comment_ID",
                table: "CourseComments",
                column: "Reply_Comment_ID",
                principalTable: "CourseComments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingComments_TrainingComments_Reply_Comment_ID",
                table: "TrainingComments",
                column: "Reply_Comment_ID",
                principalTable: "TrainingComments",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_CourseComments_Reply_Comment_ID",
                table: "CourseComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingComments_TrainingComments_Reply_Comment_ID",
                table: "TrainingComments");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_CourseComments_Reply_Comment_ID",
                table: "CourseComments",
                column: "Reply_Comment_ID",
                principalTable: "CourseComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingComments_TrainingComments_Reply_Comment_ID",
                table: "TrainingComments",
                column: "Reply_Comment_ID",
                principalTable: "TrainingComments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
