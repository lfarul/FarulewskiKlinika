using Microsoft.EntityFrameworkCore.Migrations;

namespace FarulewskiKlinika.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacjenci",
                keyColumn: "PacjentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacjenci",
                keyColumn: "PacjentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacjenci",
                keyColumn: "PacjentID",
                keyValue: 3);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pracownicy",
                keyColumn: "PracownikID",
                keyValue: 7);

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
        }
    }
}
