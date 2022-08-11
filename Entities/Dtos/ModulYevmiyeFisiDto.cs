using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    //cari banka kasa - gelir - gider 
    public class ModulYevmiyeFisiDto
    {        
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
        public int HesapPlaniId { get; set; }
        public int ToHesapPlaniId { get; set; }
        public string BorcAlacak { get; set; }
        public decimal TLTutar { get; set; }
        public decimal USDTutar { get; set; }        
        public decimal EuroTutar { get; set; }        
    }
}
