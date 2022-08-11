using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class FaturaDetayi
    {
        public int Id { get; set; }
        public int FaturaId { get; set; }
        public virtual Fatura Fatura { get; set; }
        public int HesapPlaniId { get; set; }        
        public int StokId { get; set; }
        public virtual Stok Stok {get; set;}
        public decimal Adet { get; set; }
        public decimal BirimFiyati { get; set; }
        public decimal Tutar { get; set; }
        public int KdvOrani { get; set; }
        public decimal KdvTutari { get; set; }
        public decimal ToplamTutar { get; set; }
    }

    public class FaturaDetayiConfiguration : IEntityTypeConfiguration<FaturaDetayi>
    {
        public void Configure(EntityTypeBuilder<FaturaDetayi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FaturaId).IsRequired();
            builder.Property(p => p.HesapPlaniId).IsRequired();
            builder.Property(p => p.StokId).IsRequired();
            builder.Property(p => p.Adet).IsRequired().HasPrecision(18,4);
            builder.Property(p => p.BirimFiyati).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.Tutar).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.KdvTutari).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.ToplamTutar).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.KdvOrani).IsRequired();      
        }
    }
}
