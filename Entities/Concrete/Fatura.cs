using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Fatura
    {
        public int Id { get; set; }
        public string FaturaTipi { get; set; }
        public string FaturaNumarasi { get; set; }
        public int CariId { get; set; }
        public virtual Cari Cari { get; set; }
        public DateTime Tarih { get; set; }
        public int YevmiyeFisiId { get; set; }        
    }

    public class FaturaConfiguration : IEntityTypeConfiguration<Fatura>
    {
        public void Configure(EntityTypeBuilder<Fatura> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FaturaTipi).IsRequired();
            builder.Property(p => p.FaturaNumarasi).IsRequired();
            builder.Property(p => p.CariId).IsRequired();
            builder.Property(p => p.Tarih).IsRequired();
        }
    }
}
