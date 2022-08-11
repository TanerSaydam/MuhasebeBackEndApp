using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.BankaHesabiRepository
{
    public interface IBankaHesabiService
    {
        Task<IResult> Add(BankaHesabiDto bankaHesabiDto);
        Task<IResult> Update(BankaHesabiDto bankaHesabiDto);
        Task<IResult> Delete(int bankaHesabiId);
        Task<IDataResult<List<BankaHesabi>>> GetList();
        Task<IDataResult<BankaHesabi>> GetById(int id);
        IDataResult<List<BankaHesabiListDto>> GetBankaHesabiList();
    }
}
