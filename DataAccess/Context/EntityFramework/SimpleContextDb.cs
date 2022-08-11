using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context.EntityFramework
{
    public class SimpleContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3BJ5GK9;Database=MuhasebeDb;Integrated Security=true;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<EmailParameter> EmailParameters { get; set; }
        public DbSet<HesapPlani> HesapPlanis { get; set; }
        public DbSet<YevmiyeFisi> YevmiyeFisis { get; set; }
        public DbSet<Cari> Caris { get; set; }
        public DbSet<BankaHesabi> BankaHesabis { get; set; }
        public DbSet<BorcCeki> BorcCekis { get; set; }
        public DbSet<MusteriCeki> MusteriCekis { get; set; }
        public DbSet<BorcSeneti> BorcSenetis { get; set; }
        public DbSet<MusteriSeneti> MusteriSenetis { get; set; }
        public DbSet<CekSenetMuhasebeKodu> CekSenetMuhasebeKodus { get; set; }
        public DbSet<Stok> Stoks { get; set; }
        public DbSet<StokHareketi> StokHareketis { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<FaturaDetayi> FaturaDetayis { get; set; }
        public DbSet<BorcCekiHareket> BorcCekiHarekets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmailParameterConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperationClaimConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HesapPlaniConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(YevmiyeFisiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CariConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankaHesabiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BorcCekiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusteriCekiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BorcSenetiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusteriSenetiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CekSenetMuhasebeKoduConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StokConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StokHareketiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FaturaConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FaturaDetayiConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BorcCekiHareketConfiguration).Assembly);
        }

    }
}
