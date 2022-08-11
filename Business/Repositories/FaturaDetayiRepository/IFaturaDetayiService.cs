using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.FaturaDetayiRepository
{
    public interface IFaturaDetayiService
    {
        Task<IResult> Add(FaturaDetayi faturaDetayi);
        Task<IResult> Update(FaturaDetayi faturaDetayi);
        Task<IResult> Delete(FaturaDetayi faturaDetayi);
        Task<IDataResult<List<FaturaDetayi>>> GetList();
        Task<IDataResult<FaturaDetayi>> GetById(int id);
    }
}
