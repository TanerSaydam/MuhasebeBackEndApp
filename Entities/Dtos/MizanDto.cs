using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class MizanDto : HesapPlani
    {
        public decimal Borc { get; set; }
        public decimal Alacak { get; set; }
        public decimal USDBorc { get; set; }
        public decimal USDAlacak { get; set; }
        public decimal EuroBorc { get; set; }
        public decimal EuroAlacak { get; set; }
    }
}
