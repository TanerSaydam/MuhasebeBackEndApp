using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.FaturaRepository
{
    public interface IFaturaService
    {
        Task<IResult> Add(Fatura fatura);
        Task<IResult> Update(Fatura fatura);
        Task<IResult> Delete(Fatura fatura);
        Task<IDataResult<List<Fatura>>> GetList();
        Task<IDataResult<Fatura>> GetById(int id);
    }
}
