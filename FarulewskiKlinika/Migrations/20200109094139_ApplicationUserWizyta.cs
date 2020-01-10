using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class ApplicationUserWizyta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Wizyty",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_UserId",
                table: "Wizyty",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_AspNetUsers_UserId",
                table: "Wizyty",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_AspNetUsers_UserId",
                table: "Wizyty");

            migrationBuilder.DropIndex(
                name: "IX_Wizyty_UserId",
                table: "Wizyty");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wizyty");
        }
    }
}
