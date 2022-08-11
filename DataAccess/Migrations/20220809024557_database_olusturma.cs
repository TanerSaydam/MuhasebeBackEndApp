using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class database_olusturma : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Smtp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    SSL = table.Column<bool>(type: "bit", nullable: false),
                    Html = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailParameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HesapPlanis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapTuru = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    HesapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HesapPlanis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlisBirimFiyati = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SatisBirimFiyati = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ConfirmValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsConfirm = table.Column<bool>(type: "bit", nullable: false),
                    ForgotPasswordValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForgotPasswordRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsForgotPasswordComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankaHesabis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    BankaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HesapNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankaHesabis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankaHesabis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorcCekis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerilenFirmaId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: true),
                    BankaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorcCekis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorcCekis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BorcSenetis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VerilenFirmaId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorcSenetis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorcSenetis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Caris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiDairesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VergiNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caris_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CekSenetMuhasebeKodus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorcCekiHesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    HesapPlani1Id = table.Column<int>(type: "int", nullable: true),
                    MusteriCekiHesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    HesapPlani2Id = table.Column<int>(type: "int", nullable: true),
                    BorcSenetiHesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    HesapPlani3Id = table.Column<int>(type: "int", nullable: true),
                    MusteriSenetiHesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    HesapPlani4Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CekSenetMuhasebeKodus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CekSenetMuhasebeKodus_HesapPlanis_HesapPlani1Id",
                        column: x => x.HesapPlani1Id,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CekSenetMuhasebeKodus_HesapPlanis_HesapPlani2Id",
                        column: x => x.HesapPlani2Id,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CekSenetMuhasebeKodus_HesapPlanis_HesapPlani3Id",
                        column: x => x.HesapPlani3Id,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CekSenetMuhasebeKodus_HesapPlanis_HesapPlani4Id",
                        column: x => x.HesapPlani4Id,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusteriCekis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorcluFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlinanFirmaId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: true),
                    BankaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriCekis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriCekis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusteriSenetis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorcluFirma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlinanFirmaId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusteriSenetis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusteriSenetis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YevmiyeFisis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YevmiyeFisNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    Borc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Alacak = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    USDBorc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    USDAlacak = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EuroBorc = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EuroAlacak = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YevmiyeFisis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YevmiyeFisis_HesapPlanis_HesapPlaniId",
                        column: x => x.HesapPlaniId,
                        principalTable: "HesapPlanis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YevmiyeFisiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faturas_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StokHareketis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    CariId = table.Column<int>(type: "int", nullable: false),
                    GirisMiktari = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    CikisMiktari = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    BirimFiyati = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokHareketis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokHareketis_Caris_CariId",
                        column: x => x.CariId,
                        principalTable: "Caris",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StokHareketis_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaturaDetayis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    HesapPlaniId = table.Column<int>(type: "int", nullable: false),
                    StokId = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    BirimFiyati = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    KdvOrani = table.Column<int>(type: "int", nullable: false),
                    KdvTutari = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaDetayis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaturaDetayis_Faturas_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaturaDetayis_Stoks_StokId",
                        column: x => x.StokId,
                        principalTable: "Stoks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankaHesabis_HesapPlaniId",
                table: "BankaHesabis",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_BorcCekis_HesapPlaniId",
                table: "BorcCekis",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_BorcSenetis_HesapPlaniId",
                table: "BorcSenetis",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_Caris_HesapPlaniId",
                table: "Caris",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_CekSenetMuhasebeKodus_HesapPlani1Id",
                table: "CekSenetMuhasebeKodus",
                column: "HesapPlani1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CekSenetMuhasebeKodus_HesapPlani2Id",
                table: "CekSenetMuhasebeKodus",
                column: "HesapPlani2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CekSenetMuhasebeKodus_HesapPlani3Id",
                table: "CekSenetMuhasebeKodus",
                column: "HesapPlani3Id");

            migrationBuilder.CreateIndex(
                name: "IX_CekSenetMuhasebeKodus_HesapPlani4Id",
                table: "CekSenetMuhasebeKodus",
                column: "HesapPlani4Id");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetayis_FaturaId",
                table: "FaturaDetayis",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaDetayis_StokId",
                table: "FaturaDetayis",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_Faturas_CariId",
                table: "Faturas",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriCekis_HesapPlaniId",
                table: "MusteriCekis",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_MusteriSenetis_HesapPlaniId",
                table: "MusteriSenetis",
                column: "HesapPlaniId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketis_CariId",
                table: "StokHareketis",
                column: "CariId");

            migrationBuilder.CreateIndex(
                name: "IX_StokHareketis_StokId",
                table: "StokHareketis",
                column: "StokId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YevmiyeFisis_HesapPlaniId",
                table: "YevmiyeFisis",
                column: "HesapPlaniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankaHesabis");

            migrationBuilder.DropTable(
                name: "BorcCekis");

            migrationBuilder.DropTable(
                name: "BorcSenetis");

            migrationBuilder.DropTable(
                name: "CekSenetMuhasebeKodus");

            migrationBuilder.DropTable(
                name: "EmailParameters");

            migrationBuilder.DropTable(
                name: "FaturaDetayis");

            migrationBuilder.DropTable(
                name: "MusteriCekis");

            migrationBuilder.DropTable(
                name: "MusteriSenetis");

            migrationBuilder.DropTable(
                name: "StokHareketis");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "YevmiyeFisis");

            migrationBuilder.DropTable(
                name: "Faturas");

            migrationBuilder.DropTable(
                name: "Stoks");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Caris");

            migrationBuilder.DropTable(
                name: "HesapPlanis");
        }
    }
}
