using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class BesuchUndNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grund",
                table: "Besuche",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Noten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LernenderId = table.Column<int>(type: "int", nullable: true),
                    Wert = table.Column<float>(type: "real", nullable: false),
                    Gewicht = table.Column<float>(type: "real", nullable: false),
                    Modul = table.Column<int>(type: "int", nullable: false),
                    IstMP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Noten_Lernende_LernenderId",
                        column: x => x.LernenderId,
                        principalTable: "Lernende",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Noten_LernenderId",
                table: "Noten",
                column: "LernenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noten");

            migrationBuilder.DropColumn(
                name: "Grund",
                table: "Besuche");
        }
    }
}
