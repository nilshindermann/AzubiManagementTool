using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class Besuch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PLZ",
                table: "Lehrfirmen",
                newName: "Plz");

            migrationBuilder.CreateTable(
                name: "Besuche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LernenderId = table.Column<int>(type: "int", nullable: true),
                    KontaktpersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Besuche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Besuche_Kontaktpersonen_KontaktpersonId",
                        column: x => x.KontaktpersonId,
                        principalTable: "Kontaktpersonen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Besuche_Lernende_LernenderId",
                        column: x => x.LernenderId,
                        principalTable: "Lernende",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Besuche_KontaktpersonId",
                table: "Besuche",
                column: "KontaktpersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Besuche_LernenderId",
                table: "Besuche",
                column: "LernenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Besuche");

            migrationBuilder.RenameColumn(
                name: "Plz",
                table: "Lehrfirmen",
                newName: "PLZ");
        }
    }
}
