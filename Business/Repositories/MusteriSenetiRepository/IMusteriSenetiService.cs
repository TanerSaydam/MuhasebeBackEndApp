using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.MusteriSenetiRepository
{
    public interface IMusteriSenetiService
    {
        Task<IResult> Add(MusteriSeneti musteriSeneti);
        Task<IResult> Update(MusteriSeneti musteriSeneti);
        Task<IResult> Delete(MusteriSeneti musteriSeneti);
        Task<IDataResult<List<MusteriSeneti>>> GetList();
        Task<IDataResult<MusteriSeneti>> GetById(int id);
    }
}
