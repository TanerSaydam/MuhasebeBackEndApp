using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.StokHareketiRepository
{
    public interface IStokHareketiService
    {
        Task<IResult> Add(StokHareketi stokHareketi);
        Task<IResult> Update(StokHareketi stokHareketi);
        Task<IResult> Delete(StokHareketi stokHareketi);
        Task<IDataResult<List<StokHareketi>>> GetList();
        Task<IDataResult<StokHareketi>> GetById(int id);
    }
}
