using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Cari
    {
        public int Id { get; set; }
        public int HesapPlaniId { get; set; }
        public virtual HesapPlani HesapPlani { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNumarasi { get; set; }
        public string TCNumarasi { get; set; }
    }

    public class CariConfiguration : IEntityTypeConfiguration<Cari>
    {
        public void Configure(EntityTypeBuilder<Cari> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.HesapPlaniId).IsRequired();            
        }
    }
}
