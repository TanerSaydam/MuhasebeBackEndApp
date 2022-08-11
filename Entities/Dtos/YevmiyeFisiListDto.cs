using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class YevmiyeFisiListDto : YevmiyeFisiDto
    {         
        public string HesapPlaniKodu { get; set; }
        public string HesapPlaniAdi { get; set; }        
    }
}
