using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class ChangePhotoPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Lekarze");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Lekarze",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Lekarze");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Lekarze",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
