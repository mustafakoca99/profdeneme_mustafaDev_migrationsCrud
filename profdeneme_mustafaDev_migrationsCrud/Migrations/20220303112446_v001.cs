using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace profdeneme_mustafaDev_migrationsCrud.Migrations
{
    public partial class v001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kitap",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kitapsayfasi = table.Column<int>(type: "int", nullable: false),
                    kitapturu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitap", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "yazar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yazaradi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yazaryasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_yazar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kitaptoyazar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kitapf_id = table.Column<int>(type: "int", nullable: false),
                    yazarf_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaptoyazar", x => x.id);
                    table.ForeignKey(
                        name: "FK_kitaptoyazar_kitap_kitapf_id",
                        column: x => x.kitapf_id,
                        principalTable: "kitap",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitaptoyazar_yazar_yazarf_id",
                        column: x => x.yazarf_id,
                        principalTable: "yazar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kitaptoyazar_kitapf_id",
                table: "kitaptoyazar",
                column: "kitapf_id");

            migrationBuilder.CreateIndex(
                name: "IX_kitaptoyazar_yazarf_id",
                table: "kitaptoyazar",
                column: "yazarf_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kitaptoyazar");

            migrationBuilder.DropTable(
                name: "kitap");

            migrationBuilder.DropTable(
                name: "yazar");
        }
    }
}
