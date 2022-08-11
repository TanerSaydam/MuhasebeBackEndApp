using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.CekSenetMuhasebeKoduRepository
{
    public interface ICekSenetMuhasebeKoduService
    {        
        Task<IResult> Update(CekSenetMuhasebeKodu cekSenetMuhasebeKodu);        
        Task<IDataResult<CekSenetMuhasebeKodu>> Get();
    }
}
