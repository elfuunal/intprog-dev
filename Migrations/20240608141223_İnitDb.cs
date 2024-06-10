using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace intprogödev.Migrations
{
    /// <inheritdoc />
    public partial class İnitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OgrenciDersler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDersler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numara = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dersler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kredi = table.Column<byte>(type: "tinyint", nullable: false),
                    OgrenciDersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dersler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dersler_OgrenciDersler_OgrenciDersId",
                        column: x => x.OgrenciDersId,
                        principalTable: "OgrenciDersler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OgrenciOgrenciDers",
                columns: table => new
                {
                    OgrenciDerslerId = table.Column<int>(type: "int", nullable: false),
                    OgrencilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciOgrenciDers", x => new { x.OgrenciDerslerId, x.OgrencilerId });
                    table.ForeignKey(
                        name: "FK_OgrenciOgrenciDers_OgrenciDersler_OgrenciDerslerId",
                        column: x => x.OgrenciDerslerId,
                        principalTable: "OgrenciDersler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciOgrenciDers_Ogrenciler_OgrencilerId",
                        column: x => x.OgrencilerId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_OgrenciDersId",
                table: "Dersler",
                column: "OgrenciDersId");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciOgrenciDers_OgrencilerId",
                table: "OgrenciOgrenciDers",
                column: "OgrencilerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dersler");

            migrationBuilder.DropTable(
                name: "OgrenciOgrenciDers");

            migrationBuilder.DropTable(
                name: "OgrenciDersler");

            migrationBuilder.DropTable(
                name: "Ogrenciler");
        }
    }
}
