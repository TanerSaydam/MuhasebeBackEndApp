using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BankaHesabi
    {
        public int Id { get; set; }
        public int HesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani { get; set; }
        public string BankaAdi { get; set; }
        public string HesapNumarasi { get; set; }
        public string IBAN { get; set; }
    }

    public class BankaHesabiConfiguration : IEntityTypeConfiguration<BankaHesabi>
    {
        public void Configure(EntityTypeBuilder<BankaHesabi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.HesapPlaniId).IsRequired();
            builder.Property(p => p.BankaAdi).IsRequired();
        }
    }
}
