using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CekSenetMuhasebeKoduDto
    {
        public int Id { get; set; }
        public int BorcCekiHesapPlaniId { get; set; }        
        public int MusteriCekiHesapPlaniId { get; set; }        
        public int BorcSenetiHesapPlaniId { get; set; }        
        public int MusteriSenetiHesapPlaniId { get; set; }        
    }
}
