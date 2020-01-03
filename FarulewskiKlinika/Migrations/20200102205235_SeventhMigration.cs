using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_Pracownicy_LekarzID",
                table: "Wizyty");

            migrationBuilder.DropTable(
                name: "Pracownicy");

            migrationBuilder.CreateTable(
                name: "Lekarze",
                columns: table => new
                {
                    LekarzID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Specjalizacja = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarze", x => x.LekarzID);
                });

            migrationBuilder.InsertData(
                table: "Lekarze",
                columns: new[] { "LekarzID", "Email", "Imie", "Nazwisko", "Specjalizacja" },
                values: new object[,]
                {
                    { 1, "kkowalski@klinika", "Konrad", "Kowalski", "Internista" },
                    { 2, "anowak@klinika", "Agata", "Nowak", "Laryngolog" },
                    { 3, "jkujawski@klinika", "Jan", "Kujawski", "Dermatolog" },
                    { 4, "dborowicz@klinika", "Damian", "Borowicz", "Stomatolog" },
                    { 5, "kzawadzka@klinika", "Karolina", "Zawadzka", "Okulista" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_Lekarze_LekarzID",
                table: "Wizyty",
                column: "LekarzID",
                principalTable: "Lekarze",
                principalColumn: "LekarzID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wizyty_Lekarze_LekarzID",
                table: "Wizyty");

            migrationBuilder.DropTable(
                name: "Lekarze");

            migrationBuilder.CreateTable(
                name: "Pracownicy",
                columns: table => new
                {
                    PracownikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownicy", x => x.PracownikID);
                });

            migrationBuilder.InsertData(
                table: "Pracownicy",
                columns: new[] { "PracownikID", "Email", "Imie", "Nazwisko", "Rola", "Specjalizacja" },
                values: new object[,]
                {
                    { 1, "kkowalski@medicover", "Konrad", "Kowalski", "Lekarz", "Internista" },
                    { 2, "anowak@medicover", "Agata", "Nowak", "Lekarz", "Laryngolog" },
                    { 3, "jkujawski@medicover", "Jan", "Kujawski", "Lekarz", "Dermatolog" },
                    { 4, "dborowicz@medicover", "Damian", "Borowicz", "Lekarz", "Stomatolog" },
                    { 5, "kzawadzka@medicover", "Karolina", "Zawadzka", "Lekarz", "Okulista" },
                    { 6, "mmontewska@medicover", "Magda", "Montewska", "Pielęgniarka", "Zabiegowa" },
                    { 7, "mpiotrowska@medicover", "Monika", "Piotrowska", "Asystentka", "Stomatologia" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Wizyty_Pracownicy_LekarzID",
                table: "Wizyty",
                column: "LekarzID",
                principalTable: "Pracownicy",
                principalColumn: "PracownikID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
