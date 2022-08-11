using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BorcCekiHareket
    {
        public int Id { get; set; }
        public int BorcCekiId { get; set; }
        public virtual BorcCeki BorcCeki { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public string YevmiyeFisiNumarasi { get; set; }        
        public int HesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani { get; set; }
    }

    public class BorcCekiHareketConfiguration : IEntityTypeConfiguration<BorcCekiHareket>
    {
        public void Configure(EntityTypeBuilder<BorcCekiHareket> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.BorcCekiId).IsRequired();
            builder.Property(p => p.Tarih).IsRequired();
            builder.Property(p => p.Aciklama).IsRequired();
            builder.Property(p => p.YevmiyeFisiNumarasi).IsRequired();
            builder.Property(p => p.HesapPlaniId).IsRequired();            
        }
    }
}
