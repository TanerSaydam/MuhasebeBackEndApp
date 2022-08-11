using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BankaHesabiDto
    {
        public int Id { get; set; }
        public string HesapPlaniKodu { get; set; }        
        public string HesapPlaniAdi { get; set; }        
        public string BankaAdi { get; set; }
        public string HesapNumarasi { get; set; }
        public string IBAN { get; set; }
    }
}
