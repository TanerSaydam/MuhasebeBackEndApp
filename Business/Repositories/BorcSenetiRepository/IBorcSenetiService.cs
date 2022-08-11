using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.BorcSenetiRepository
{
    public interface IBorcSenetiService
    {
        Task<IResult> Add(BorcSeneti borcSeneti);
        Task<IResult> Update(BorcSeneti borcSeneti);
        Task<IResult> Delete(BorcSeneti borcSeneti);
        Task<IDataResult<List<BorcSeneti>>> GetList();
        Task<IDataResult<BorcSeneti>> GetById(int id);
    }
}
