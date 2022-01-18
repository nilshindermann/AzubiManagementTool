using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lehrfirmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLZ = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrfirmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lernende",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Geschlecht = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beruf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klassenjahrgang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Schulklasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BMS = table.Column<bool>(type: "bit", nullable: false),
                    LehrfirmaId = table.Column<int>(type: "int", nullable: false),
                    BeginnGrundausbildung = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndeGrundausbildung = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lernende", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lernende_Lehrfirmen_LehrfirmaId",
                        column: x => x.LehrfirmaId,
                        principalTable: "Lehrfirmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kontaktpersonen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LehrfirmaId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LernendeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kontaktpersonen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kontaktpersonen_Lehrfirmen_LehrfirmaId",
                        column: x => x.LehrfirmaId,
                        principalTable: "Lehrfirmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kontaktpersonen_Lernende_LernendeId",
                        column: x => x.LernendeId,
                        principalTable: "Lernende",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktpersonen_LehrfirmaId",
                table: "Kontaktpersonen",
                column: "LehrfirmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktpersonen_LernendeId",
                table: "Kontaktpersonen",
                column: "LernendeId");

            migrationBuilder.CreateIndex(
                name: "IX_Lernende_LehrfirmaId",
                table: "Lernende",
                column: "LehrfirmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kontaktpersonen");

            migrationBuilder.DropTable(
                name: "Lernende");

            migrationBuilder.DropTable(
                name: "Lehrfirmen");
        }
    }
}
