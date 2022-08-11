using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class cek_hareket_entity_olusturma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorcCekiHarekets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorcCekiId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YevmiyeFisiId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorcCekiHarekets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorcCekiHarekets_BorcCekis_BorcCekiId",
                        column: x => x.BorcCekiId,
                        principalTable: "BorcCekis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorcCekiHarekets_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorcCekiHarekets_BorcCekiId",
                table: "BorcCekiHarekets",
                column: "BorcCekiId");

            migrationBuilder.CreateIndex(
                name: "IX_BorcCekiHarekets_HesapPlaniId",
                table: "BorcCekiHarekets",
                column: "HesapPlaniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorcCekiHarekets");
        }
    }
}
