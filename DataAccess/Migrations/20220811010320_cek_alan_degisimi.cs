using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class cek_alan_degisimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "YevmiyeFisis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EuroTutar",
                table: "MusteriCekis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "USDTutar",
                table: "MusteriCekis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "EuroTutar",
                table: "BorcCekis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "USDTutar",
                table: "BorcCekis",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EuroTutar",
                table: "MusteriCekis");

            migrationBuilder.DropColumn(
                name: "USDTutar",
                table: "MusteriCekis");

            migrationBuilder.DropColumn(
                name: "EuroTutar",
                table: "BorcCekis");

            migrationBuilder.DropColumn(
                name: "USDTutar",
                table: "BorcCekis");

            migrationBuilder.AlterColumn<string>(
                name: "Aciklama",
                table: "YevmiyeFisis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
