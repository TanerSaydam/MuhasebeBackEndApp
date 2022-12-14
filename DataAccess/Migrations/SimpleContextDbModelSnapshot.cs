// <auto-generated />
using System;
using DataAccess.Context.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(SimpleContextDb))]
    partial class SimpleContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.BankaHesabi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HesapNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<string>("IBAN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("BankaHesabis");
                });

            modelBuilder.Entity("Entities.Concrete.BorcCeki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EuroTutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SeriNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("USDTutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VadeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BorcCekis");
                });

            modelBuilder.Entity("Entities.Concrete.BorcCekiHareket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BorcCekiId")
                        .HasColumnType("int");

                    b.Property<int>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("YevmiyeFisiNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BorcCekiId");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("BorcCekiHarekets");
                });

            modelBuilder.Entity("Entities.Concrete.BorcSeneti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VadeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("VerilenFirmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("BorcSenetis");
                });

            modelBuilder.Entity("Entities.Concrete.Cari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TCNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VergiDairesi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VergiNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("Caris");
                });

            modelBuilder.Entity("Entities.Concrete.CekSenetMuhasebeKodu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BorcCekiHesapPlaniId")
                        .HasColumnType("int");

                    b.Property<int>("BorcSenetiHesapPlaniId")
                        .HasColumnType("int");

                    b.Property<int?>("HesapPlani1Id")
                        .HasColumnType("int");

                    b.Property<int?>("HesapPlani2Id")
                        .HasColumnType("int");

                    b.Property<int?>("HesapPlani3Id")
                        .HasColumnType("int");

                    b.Property<int?>("HesapPlani4Id")
                        .HasColumnType("int");

                    b.Property<int>("MusteriCekiHesapPlaniId")
                        .HasColumnType("int");

                    b.Property<int>("MusteriSenetiHesapPlaniId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlani1Id");

                    b.HasIndex("HesapPlani2Id");

                    b.HasIndex("HesapPlani3Id");

                    b.HasIndex("HesapPlani4Id");

                    b.ToTable("CekSenetMuhasebeKodus");
                });

            modelBuilder.Entity("Entities.Concrete.EmailParameter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Html")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("SSL")
                        .HasColumnType("bit");

                    b.Property<string>("Smtp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailParameters");
                });

            modelBuilder.Entity("Entities.Concrete.Fatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CariId")
                        .HasColumnType("int");

                    b.Property<string>("FaturaNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaturaTipi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("YevmiyeFisiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.ToTable("Faturas");
                });

            modelBuilder.Entity("Entities.Concrete.FaturaDetayi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Adet")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("BirimFiyati")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FaturaId")
                        .HasColumnType("int");

                    b.Property<int>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<int>("KdvOrani")
                        .HasColumnType("int");

                    b.Property<decimal>("KdvTutari")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StokId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamTutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FaturaId");

                    b.HasIndex("StokId");

                    b.ToTable("FaturaDetayis");
                });

            modelBuilder.Entity("Entities.Concrete.HesapPlani", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("HesapAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HesapKodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HesapTuru")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("HesapPlanis");
                });

            modelBuilder.Entity("Entities.Concrete.MusteriCeki", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlinanFirmaId")
                        .HasColumnType("int");

                    b.Property<string>("BankaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BorcluFirma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EuroTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<string>("SeriNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("USDTutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VadeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("MusteriCekis");
                });

            modelBuilder.Entity("Entities.Concrete.MusteriSeneti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlinanFirmaId")
                        .HasColumnType("int");

                    b.Property<string>("BorcluFirma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tutar")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("VadeTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("MusteriSenetis");
                });

            modelBuilder.Entity("Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.Stok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AlisBirimFiyati")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SatisBirimFiyati")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StokAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stoks");
                });

            modelBuilder.Entity("Entities.Concrete.StokHareketi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BirimFiyati")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CariId")
                        .HasColumnType("int");

                    b.Property<decimal>("CikisMiktari")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("GirisMiktari")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("StokId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CariId");

                    b.HasIndex("StokId");

                    b.ToTable("StokHareketis");
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConfirmValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ForgotPasswordRequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ForgotPasswordValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForgotPasswordComplete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.YevmiyeFisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Alacak")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Borc")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EuroAlacak")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EuroBorc")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HesapPlaniId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("USDAlacak")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("USDBorc")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("YevmiyeFisNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HesapPlaniId");

                    b.ToTable("YevmiyeFisis");
                });

            modelBuilder.Entity("Entities.Concrete.BankaHesabi", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.BorcCekiHareket", b =>
                {
                    b.HasOne("Entities.Concrete.BorcCeki", "BorcCeki")
                        .WithMany()
                        .HasForeignKey("BorcCekiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BorcCeki");

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.BorcSeneti", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId");

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.Cari", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.CekSenetMuhasebeKodu", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani1")
                        .WithMany()
                        .HasForeignKey("HesapPlani1Id");

                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani2")
                        .WithMany()
                        .HasForeignKey("HesapPlani2Id");

                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani3")
                        .WithMany()
                        .HasForeignKey("HesapPlani3Id");

                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani4")
                        .WithMany()
                        .HasForeignKey("HesapPlani4Id");

                    b.Navigation("HesapPlani1");

                    b.Navigation("HesapPlani2");

                    b.Navigation("HesapPlani3");

                    b.Navigation("HesapPlani4");
                });

            modelBuilder.Entity("Entities.Concrete.Fatura", b =>
                {
                    b.HasOne("Entities.Concrete.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cari");
                });

            modelBuilder.Entity("Entities.Concrete.FaturaDetayi", b =>
                {
                    b.HasOne("Entities.Concrete.Fatura", "Fatura")
                        .WithMany()
                        .HasForeignKey("FaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Stok", "Stok")
                        .WithMany()
                        .HasForeignKey("StokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fatura");

                    b.Navigation("Stok");
                });

            modelBuilder.Entity("Entities.Concrete.MusteriCeki", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId");

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.MusteriSeneti", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId");

                    b.Navigation("HesapPlani");
                });

            modelBuilder.Entity("Entities.Concrete.StokHareketi", b =>
                {
                    b.HasOne("Entities.Concrete.Cari", "Cari")
                        .WithMany()
                        .HasForeignKey("CariId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Stok", "Stok")
                        .WithMany()
                        .HasForeignKey("StokId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cari");

                    b.Navigation("Stok");
                });

            modelBuilder.Entity("Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany()
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.YevmiyeFisi", b =>
                {
                    b.HasOne("Entities.Concrete.HesapPlani", "HesapPlani")
                        .WithMany()
                        .HasForeignKey("HesapPlaniId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HesapPlani");
                });
#pragma warning restore 612, 618
        }
    }
}
