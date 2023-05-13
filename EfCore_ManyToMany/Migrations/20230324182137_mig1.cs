using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore_ManyToMany.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyuncuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilmOyuncu",
                columns: table => new
                {
                    FilmlerId = table.Column<int>(type: "int", nullable: false),
                    OyuncularId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOyuncu", x => new { x.FilmlerId, x.OyuncularId });
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_Filmler_FilmlerId",
                        column: x => x.FilmlerId,
                        principalTable: "Filmler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_Oyuncular_OyuncularId",
                        column: x => x.OyuncularId,
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncu_OyuncularId",
                table: "FilmOyuncu",
                column: "OyuncularId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmOyuncu");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Oyuncular");
        }
    }
}
