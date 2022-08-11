using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.CariRepository
{
    public interface ICariService
    {
        Task<IResult> Add(CariDto cariDto);
        Task<IResult> Update(CariDto cariDto);
        Task<IResult> Delete(int cariId);
        Task<IDataResult<List<Cari>>> GetList();
        IDataResult<List<CariListDto>> GetCariList();
        Task<IDataResult<Cari>> GetById(int id);
    }
}
