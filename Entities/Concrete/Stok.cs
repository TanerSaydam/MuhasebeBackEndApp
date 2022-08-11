using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Stok
    {
        public int Id { get; set; }
        public string StokAdi { get; set; }
        public decimal AlisBirimFiyati { get; set; }
        public decimal SatisBirimFiyati { get; set; }
    }

    public class StokConfiguration : IEntityTypeConfiguration<Stok>
    {
        public void Configure(EntityTypeBuilder<Stok> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.StokAdi).IsRequired();
            builder.Property(p => p.AlisBirimFiyati).IsRequired().HasPrecision(18, 2);
            builder.Property(p => p.SatisBirimFiyati).IsRequired().HasPrecision(18, 2);
        }
    }
}
