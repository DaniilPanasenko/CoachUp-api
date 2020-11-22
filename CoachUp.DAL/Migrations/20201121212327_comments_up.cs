using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachUp.DAL.Migrations
{
    public partial class comments_up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Messge",
                table: "Notifications",
                newName: "Message");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Notifications",
                newName: "Messge");
        }
    }
}
