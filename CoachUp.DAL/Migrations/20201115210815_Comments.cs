using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class Comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reply_Comment_ID = table.Column<int>(type: "int", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    User_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseComments_CourseComments_Reply_Comment_ID",
                        column: x => x.Reply_Comment_ID,
                        principalTable: "CourseComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseComments_Courses_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseComments_Users_User_Login",
                        column: x => x.User_Login,
                        principalTable: "Users",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateTable(
                name: "TrainingComments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reply_Comment_ID = table.Column<int>(type: "int", nullable: false),
                    Training_Id = table.Column<int>(type: "int", nullable: false),
                    User_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingComments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TrainingComments_TrainingComments_Reply_Comment_ID",
                        column: x => x.Reply_Comment_ID,
                        principalTable: "TrainingComments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TrainingComments_Trainings_Training_Id",
                        column: x => x.Training_Id,
                        principalTable: "Trainings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainingComments_Users_User_Login",
                        column: x => x.User_Login,
                        principalTable: "Users",
                        principalColumn: "Login");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_Course_Id",
                table: "CourseComments",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_Reply_Comment_ID",
                table: "CourseComments",
                column: "Reply_Comment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseComments_User_Login",
                table: "CourseComments",
                column: "User_Login");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingComments_Reply_Comment_ID",
                table: "TrainingComments",
                column: "Reply_Comment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingComments_Training_Id",
                table: "TrainingComments",
                column: "Training_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingComments_User_Login",
                table: "TrainingComments",
                column: "User_Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseComments");

            migrationBuilder.DropTable(
                name: "TrainingComments");
        }
    }
}
