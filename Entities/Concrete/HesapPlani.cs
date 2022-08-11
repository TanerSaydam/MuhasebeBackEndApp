using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HesapPlani
    {
        public int Id { get; set; }
        public string HesapKodu { get; set; }
        public string HesapTuru { get; set; }
        public string HesapAdi { get; set; }
    }

    public class HesapPlaniConfiguration : IEntityTypeConfiguration<HesapPlani>
    {
        public void Configure(EntityTypeBuilder<HesapPlani> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.HesapKodu).IsRequired();
            builder.Property(p => p.HesapTuru).IsRequired().HasMaxLength(1);
            builder.Property(p => p.HesapAdi).IsRequired();
        }
    }
}
