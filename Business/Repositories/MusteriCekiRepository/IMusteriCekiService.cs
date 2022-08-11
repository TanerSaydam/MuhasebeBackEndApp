using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.MusteriCekiRepository
{
    public interface IMusteriCekiService
    {
        Task<IResult> Add(MusteriCeki musteriCeki);
        Task<IResult> Update(MusteriCeki musteriCeki);
        Task<IResult> Delete(MusteriCeki musteriCeki);
        Task<IDataResult<List<MusteriCeki>>> GetList();
        Task<IDataResult<MusteriCeki>> GetById(int id);
    }
}
