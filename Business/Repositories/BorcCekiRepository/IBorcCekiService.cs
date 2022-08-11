using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.BorcCekiRepository
{
    public interface IBorcCekiService
    {
        Task<IResult> Add(BorcCeki borcCeki, int verilenFirmaId);        
        Task<IResult> Delete(BorcCeki borcCeki);
        Task<IDataResult<List<BorcCeki>>> GetList();
        Task<IDataResult<BorcCeki>> GetById(int id);
    }
}
