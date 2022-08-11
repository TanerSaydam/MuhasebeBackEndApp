using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.YevmiyeFisiRepository
{
    public interface IYevmiyeFisiService
    {
        Task<IResult> Add(YevmiyeFisi yevmiyeFisi);
        Task<IDataResult<YevmiyeFisi>> ModulAdd(ModulYevmiyeFisiDto modulYevmiyeFisiDto);
        Task<IResult> Update(YevmiyeFisi yevmiyeFisi);
        Task<IResult> Delete(YevmiyeFisi yevmiyeFisi);
        Task<IResult> DeleteWithYevmiyeFisiNumarasi(string yevmiyeFisiNumarasi);
        Task<IDataResult<List<YevmiyeFisi>>> GetList();
        IDataResult<List<YevmiyeFisiDto>> GetYevmiyeFisiWithHesapPlaniId(int hesapPlaniId, string tarih1, string tarih2);
        Task<IDataResult<YevmiyeFisi>> GetById(int id);
        IDataResult<List<YevmiyeFisiListDto>> GetYevmiyeFisiList(string tarih1, string tarih2);
    }
}
