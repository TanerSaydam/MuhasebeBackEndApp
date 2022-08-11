using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.YevmiyeFisiRepository
{
    public interface IYevmiyeFisiDal : IEntityRepository<YevmiyeFisi>
    {
        List<YevmiyeFisiDto> GetYevmiyeFisiWithHesapPlaniId(int hesapPlaniId, DateTime tarih1, DateTime tarih2);
        List<YevmiyeFisiListDto> GetYevmiyeFisiList(DateTime tarih1, DateTime tarih2);
        Task<YevmiyeFisi> GetLastYevmiyeFisiNumarasi();
    }
}
