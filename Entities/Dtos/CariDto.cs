using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CariDto
    {
        public int Id { get; set; }
        public string CariAdi { get; set; }
        public string HesapPlaniKodu { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string VergiDairesi { get; set; }
        public string VergiNumarasi { get; set; }
        public string TCNumarasi { get; set; }
    }
}
