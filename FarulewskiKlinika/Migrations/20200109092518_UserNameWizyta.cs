using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class UserNameWizyta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty");

            migrationBuilder.AlterColumn<int>(
                name: "PacjentID",
                table: "Wizyty",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserName",
                table: "Wizyty",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty",
                column: "PacjentID",
                principalTable: "Pacjenci",
                principalColumn: "PacjentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Wizyty");

            migrationBuilder.AlterColumn<int>(
                name: "PacjentID",
                table: "Wizyty",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty",
                column: "PacjentID",
                principalTable: "Pacjenci",
                principalColumn: "PacjentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
