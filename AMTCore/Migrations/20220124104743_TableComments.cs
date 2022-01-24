using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class TableComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Noten",
                comment: "Tabelle in der die Noten der Lernenden abgespeichert sind");

            migrationBuilder.AlterTable(
                name: "Lernende",
                comment: "Tabelle Lernende");

            migrationBuilder.AlterTable(
                name: "Lehrfirmen",
                comment: "Tabelle der Lehrfirmen mit Adresse");

            migrationBuilder.AlterTable(
                name: "Kontaktpersonen",
                comment: "Tabelle der Kontaktpersonen");

            migrationBuilder.AlterTable(
                name: "Besuche",
                comment: "Besuche");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Noten",
                oldComment: "Tabelle in der die Noten der Lernenden abgespeichert sind");

            migrationBuilder.AlterTable(
                name: "Lernende",
                oldComment: "Tabelle Lernende");

            migrationBuilder.AlterTable(
                name: "Lehrfirmen",
                oldComment: "Tabelle der Lehrfirmen mit Adresse");

            migrationBuilder.AlterTable(
                name: "Kontaktpersonen",
                oldComment: "Tabelle der Kontaktpersonen");

            migrationBuilder.AlterTable(
                name: "Besuche",
                oldComment: "Besuche");
        }
    }
}
