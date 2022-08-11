using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public abstract class SenetAbstract
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VadeTarihi { get; set; }
        public decimal Tutar { get; set; }
    }
}
