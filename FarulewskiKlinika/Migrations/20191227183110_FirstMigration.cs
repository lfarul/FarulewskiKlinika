using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    PacjentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pesel = table.Column<string>(nullable: false),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.PacjentID);
                });

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    PracownikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Rola = table.Column<string>(nullable: false),
                    Specjalizacja = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.PracownikID);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    WizytaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjentID = table.Column<int>(nullable: false),
                    LekarzID = table.Column<int>(nullable: false),
                    Specjalizacja = table.Column<string>(nullable: true),
                    DataWizyty = table.Column<DateTime>(nullable: false),
                    Zalecenia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.WizytaID);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pracownicy_LekarzID",
                        column: x => x.LekarzID,
                        principalTable: "Pracownicy",
                        principalColumn: "PracownikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjenci_PacjentID",
                        column: x => x.PacjentID,
                        principalTable: "Pacjenci",
                        principalColumn: "PacjentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pacjenci",
                columns: new[] { "PacjentID", "Email", "Imie", "Nazwisko", "Pesel" },
                values: new object[] { 1, "styczen@wp.pl", "Konrad", "Styczen", "11111111111" });

            migrationBuilder.InsertData(
                table: "Pacjenci",
                columns: new[] { "PacjentID", "Email", "Imie", "Nazwisko", "Pesel" },
                values: new object[] { 2, "luty@wp.pl", "Agata", "Luty", "22222222222" });

            migrationBuilder.InsertData(
                table: "Pacjenci",
                columns: new[] { "PacjentID", "Email", "Imie", "Nazwisko", "Pesel" },
                values: new object[] { 3, "marzec@wp.pl", "Jan", "Marzec", "33333333333" });

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_LekarzID",
                table: "Wizyty",
                column: "LekarzID");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentID",
                table: "Wizyty",
                column: "PacjentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.DropTable(
                name: "Pacjenci");
        }
    }
}
