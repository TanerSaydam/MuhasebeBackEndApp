using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.BorcCekiHareketRepository
{
    public interface IBorcCekiHareketService
    {
        Task<IResult> Add(BorcCekiHareket borcCekiHareket);
        Task<IResult> Update(BorcCekiHareket borcCekiHareket);
        Task<IResult> Delete(BorcCekiHareket borcCekiHareket);
        Task<IDataResult<List<BorcCekiHareket>>> GetList();
        Task<IDataResult<BorcCekiHareket>> GetById(int id);
    }
}
