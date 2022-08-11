using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CekSenetMuhasebeKodu
    {
        public int Id { get; set; }
        public int BorcCekiHesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani1 { get; set; }
        public int MusteriCekiHesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani2 { get; set; }
        public int BorcSenetiHesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani3 { get; set; }
        public int MusteriSenetiHesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani4 { get; set; }
    }

    public class CekSenetMuhasebeKoduConfiguration : IEntityTypeConfiguration<CekSenetMuhasebeKodu>
    {
        public void Configure(EntityTypeBuilder<CekSenetMuhasebeKodu> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BorcCekiHesapPlaniId).IsRequired();
            builder.Property(p => p.MusteriCekiHesapPlaniId).IsRequired();
            builder.Property(p => p.BorcSenetiHesapPlaniId).IsRequired();
            builder.Property(p => p.MusteriSenetiHesapPlaniId).IsRequired();
        }
    }
}
