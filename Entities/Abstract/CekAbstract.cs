using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class CekAbstract
    {
        public int Id { get; set; }
        public string BankaAdi { get; set; }
        public string SeriNo { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VadeTarihi { get; set; }
        public decimal Tutar { get; set; }
        public decimal USDTutar { get; set; }
        public decimal EuroTutar { get; set; }
    }
}
