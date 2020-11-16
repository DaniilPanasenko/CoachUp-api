using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class Career : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SYear = table.Column<int>(type: "int", nullable: false),
                    FYear = table.Column<int>(type: "int", nullable: false),
                    Coach_Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Careers_Coaches_Coach_Login",
                        column: x => x.Coach_Login,
                        principalTable: "Coaches",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Careers_Coach_Login",
                table: "Careers",
                column: "Coach_Login");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Careers");

            
        }
    }
}
