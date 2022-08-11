using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class cek_hareket_entity_olusturma2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YevmiyeFisiId",
                table: "BorcCekiHarekets");

            migrationBuilder.AddColumn<string>(
                name: "YevmiyeFisiNumarasi",
                table: "BorcCekiHarekets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YevmiyeFisiNumarasi",
                table: "BorcCekiHarekets");

            migrationBuilder.AddColumn<int>(
                name: "YevmiyeFisiId",
                table: "BorcCekiHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
