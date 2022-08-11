using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BorcCeki : CekAbstract
    {                
    }

    public class BorcCekiConfiguration : IEntityTypeConfiguration<BorcCeki>
    {
        public void Configure(EntityTypeBuilder<BorcCeki> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BankaAdi).IsRequired();
            builder.Property(p => p.SeriNo).IsRequired();
            builder.Property(p => p.Tarih).IsRequired();
            builder.Property(p => p.VadeTarihi).IsRequired();
            builder.Property(p => p.Tutar).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.USDTutar).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.EuroTutar).IsRequired().HasPrecision(18,2);
            
        }
    }
}
