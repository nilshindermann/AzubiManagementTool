using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMTCore.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kontaktpersonen_Lernende_LernendeId",
                table: "Kontaktpersonen");

            migrationBuilder.DropIndex(
                name: "IX_Kontaktpersonen_LernendeId",
                table: "Kontaktpersonen");

            migrationBuilder.DropColumn(
                name: "LernendeId",
                table: "Kontaktpersonen");

            migrationBuilder.CreateTable(
                name: "LernendeKontaktpersonen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LernendeId = table.Column<int>(type: "int", nullable: true),
                    KontaktpersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LernendeKontaktpersonen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LernendeKontaktpersonen_Kontaktpersonen_KontaktpersonId",
                        column: x => x.KontaktpersonId,
                        principalTable: "Kontaktpersonen",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LernendeKontaktpersonen_Lernende_LernendeId",
                        column: x => x.LernendeId,
                        principalTable: "Lernende",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LernendeKontaktpersonen_KontaktpersonId",
                table: "LernendeKontaktpersonen",
                column: "KontaktpersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LernendeKontaktpersonen_LernendeId",
                table: "LernendeKontaktpersonen",
                column: "LernendeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LernendeKontaktpersonen");

            migrationBuilder.AddColumn<int>(
                name: "LernendeId",
                table: "Kontaktpersonen",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kontaktpersonen_LernendeId",
                table: "Kontaktpersonen",
                column: "LernendeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kontaktpersonen_Lernende_LernendeId",
                table: "Kontaktpersonen",
                column: "LernendeId",
                principalTable: "Lernende",
                principalColumn: "Id");
        }
    }
}
