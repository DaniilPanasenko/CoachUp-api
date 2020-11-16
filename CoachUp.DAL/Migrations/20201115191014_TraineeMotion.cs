using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class TraineeMotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraineeMotions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_ID = table.Column<int>(type: "int", nullable: false),
                    Motion_ID = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Persent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeMotions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TraineeMotions_Members_Member_ID",
                        column: x => x.Member_ID,
                        principalTable: "Members",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TraineeMotions_Motions_Motion_ID",
                        column: x => x.Motion_ID,
                        principalTable: "Motions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeMotions_Member_ID",
                table: "TraineeMotions",
                column: "Member_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeMotions_Motion_ID",
                table: "TraineeMotions",
                column: "Motion_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineeMotions");
        }
    }
}
