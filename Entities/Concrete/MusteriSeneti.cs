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
    public class MusteriSeneti : SenetAbstract
    {
        public string BorcluFirma { get; set; }
        public int AlinanFirmaId { get; set; }
        public virtual HesapPlani HesapPlani { get; set; }
    }

    public class MusteriSenetiConfiguration : IEntityTypeConfiguration<MusteriSeneti>
    {
        public void Configure(EntityTypeBuilder<MusteriSeneti> builder)
        {
            builder.HasKey(p => p.Id);            
            builder.Property(p => p.Tarih).IsRequired();
            builder.Property(p => p.VadeTarihi).IsRequired();
            builder.Property(p => p.Tutar).IsRequired().HasPrecision(18, 2);
            builder.Property(p => p.AlinanFirmaId).IsRequired();
        }
    }
}
