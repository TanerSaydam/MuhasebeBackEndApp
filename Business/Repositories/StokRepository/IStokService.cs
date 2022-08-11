using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.StokRepository
{
    public interface IStokService
    {
        Task<IResult> Add(Stok stok);
        Task<IResult> Update(Stok stok);
        Task<IResult> Delete(Stok stok);
        Task<IDataResult<List<Stok>>> GetList();
        Task<IDataResult<Stok>> GetById(int id);
    }
}
