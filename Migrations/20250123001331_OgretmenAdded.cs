using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ef_core_app.Migrations
{
    /// <inheritdoc />
    public partial class OgretmenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OgretmenAd = table.Column<string>(type: "TEXT", nullable: false),
                    OgretmenSoyad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Kayitlar_KursId",
                table: "Kayitlar",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_Kayitlar_OgrenciId",
                table: "Kayitlar",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kayitlar_Kurslar_KursId",
                table: "Kayitlar",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "KursId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kayitlar_Ogrenciler_OgrenciId",
                table: "Kayitlar",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kayitlar_Kurslar_KursId",
                table: "Kayitlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kayitlar_Ogrenciler_OgrenciId",
                table: "Kayitlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_OgretmenId",
                table: "Kurslar");

            migrationBuilder.DropIndex(
                name: "IX_Kayitlar_KursId",
                table: "Kayitlar");

            migrationBuilder.DropIndex(
                name: "IX_Kayitlar_OgrenciId",
                table: "Kayitlar");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Kurslar");
        }
    }
}
