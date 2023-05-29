using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FayrouzGlobitelAssignmentFullStack.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Id",
                table: "Complains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complains_User_Id",
                table: "Complains",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Complains_AspNetUsers_User_Id",
                table: "Complains",
                column: "User_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complains_AspNetUsers_User_Id",
                table: "Complains");

            migrationBuilder.DropIndex(
                name: "IX_Complains_User_Id",
                table: "Complains");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Complains");
        }
    }
}
