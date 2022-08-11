using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class YevmiyeFisi
    {
        public int Id { get; set; }
        public string YevmiyeFisNumarasi { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int HesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani { get; set; }
        public decimal Borc { get; set; }
        public decimal Alacak { get; set; }
        public decimal USDBorc { get; set; }
        public decimal USDAlacak { get; set; }
        public decimal EuroBorc { get; set; }
        public decimal EuroAlacak { get; set; }
    }

    public class YevmiyeFisiConfiguration : IEntityTypeConfiguration<YevmiyeFisi>
    {
        public void Configure(EntityTypeBuilder<YevmiyeFisi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.YevmiyeFisNumarasi).IsRequired();
            builder.Property(p=> p.Tarih).IsRequired();
            builder.Property(p=> p.Aciklama).IsRequired();
            builder.Property(p => p.HesapPlaniId).IsRequired();
            builder.Property(p => p.Borc).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.Alacak).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.USDBorc).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.USDAlacak).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.EuroBorc).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.EuroAlacak).IsRequired().HasPrecision(18,2);
            
        }
    }
}
