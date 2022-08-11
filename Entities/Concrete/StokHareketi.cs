using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class StokHareketi
    {
        public int Id { get; set; }
        public int StokId { get; set; }
        public virtual Stok Stok { get; set; }
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public decimal GirisMiktari { get; set; }
        public decimal CikisMiktari { get; set; }
        public decimal BirimFiyati { get; set; }        
    }

    public class StokHareketiConfiguration : IEntityTypeConfiguration<StokHareketi>
    {
        public void Configure(EntityTypeBuilder<StokHareketi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StokId).IsRequired();
            builder.Property(p => p.CariId).IsRequired();
            builder.Property(p => p.GirisMiktari).IsRequired().HasPrecision(18,4);
            builder.Property(p => p.CikisMiktari).IsRequired().HasPrecision(18, 4);
            builder.Property(p => p.BirimFiyati).IsRequired().HasPrecision(18, 2);
        }
    }
}
