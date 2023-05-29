using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FayrouzGlobitelAssignmentFullStack.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Suggestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_User_Id",
                table: "Suggestions",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_AspNetUsers_User_Id",
                table: "Suggestions",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_AspNetUsers_User_Id",
                table: "Suggestions");

            migrationBuilder.DropIndex(
                name: "IX_Suggestions_User_Id",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Suggestions");
        }
    }
}
