using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetapp.Migrations
{
    public partial class add2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable");

            migrationBuilder.DropIndex(
                name: "IX_CartTable_UserId",
                table: "CartTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartTable",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_UserId",
                table: "CartTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartTable_UserTable_UserId",
                table: "CartTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "Email");
        }
    }
}
