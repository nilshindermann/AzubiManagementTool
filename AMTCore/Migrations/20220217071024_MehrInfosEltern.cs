using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class MehrInfosEltern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Noten",
                comment: "Noten der Lernenden in den Modulen",
                oldComment: "Tabelle in der die Noten der Lernenden abgespeichert sind");

            migrationBuilder.AlterTable(
                name: "Lernende",
                comment: "Auszubildende im Ausbildungszentrum Zürcher Oberland",
                oldComment: "Tabelle Lernende");

            migrationBuilder.AlterTable(
                name: "Lehrfirmen",
                comment: "Lehrfirmen mit Adresse",
                oldComment: "Tabelle der Lehrfirmen mit Adresse");

            migrationBuilder.AlterTable(
                name: "Kontaktpersonen",
                comment: "Kontaktpersonen der Lernenden bei Lehrfirmen",
                oldComment: "Tabelle der Kontaktpersonen");

            migrationBuilder.AlterTable(
                name: "Besuche",
                comment: "Besuche von Kontaktpersonen",
                oldComment: "Besuche");

            migrationBuilder.AddColumn<string>(
                name: "Aemtli",
                table: "Lernende",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Anmerkungen",
                table: "Lernende",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailEltern",
                table: "Lernende",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Handynummer",
                table: "Lernende",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonEltern",
                table: "Lernende",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aemtli",
                table: "Lernende");

            migrationBuilder.DropColumn(
                name: "Anmerkungen",
                table: "Lernende");

            migrationBuilder.DropColumn(
                name: "EmailEltern",
                table: "Lernende");

            migrationBuilder.DropColumn(
                name: "Handynummer",
                table: "Lernende");

            migrationBuilder.DropColumn(
                name: "TelefonEltern",
                table: "Lernende");

            migrationBuilder.AlterTable(
                name: "Noten",
                comment: "Tabelle in der die Noten der Lernenden abgespeichert sind",
                oldComment: "Noten der Lernenden in den Modulen");

            migrationBuilder.AlterTable(
                name: "Lernende",
                comment: "Tabelle Lernende",
                oldComment: "Auszubildende im Ausbildungszentrum Zürcher Oberland");

            migrationBuilder.AlterTable(
                name: "Lehrfirmen",
                comment: "Tabelle der Lehrfirmen mit Adresse",
                oldComment: "Lehrfirmen mit Adresse");

            migrationBuilder.AlterTable(
                name: "Kontaktpersonen",
                comment: "Tabelle der Kontaktpersonen",
                oldComment: "Kontaktpersonen der Lernenden bei Lehrfirmen");

            migrationBuilder.AlterTable(
                name: "Besuche",
                comment: "Besuche",
                oldComment: "Besuche von Kontaktpersonen");
        }
    }
}
