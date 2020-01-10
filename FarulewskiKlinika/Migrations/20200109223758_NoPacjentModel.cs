using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class NoPacjentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty");

            migrationBuilder.DropTable(
                name: "Pacjenci");

            migrationBuilder.DropIndex(
                name: "IX_Wizyty_PacjentID",
                table: "Wizyty");

            migrationBuilder.DropColumn(
                name: "PacjentID",
                table: "Wizyty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacjentID",
                table: "Wizyty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    PacjentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.PacjentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentID",
                table: "Wizyty",
                column: "PacjentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_Pacjenci_PacjentID",
                table: "Wizyty",
                column: "PacjentID",
                principalTable: "Pacjenci",
                principalColumn: "PacjentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
