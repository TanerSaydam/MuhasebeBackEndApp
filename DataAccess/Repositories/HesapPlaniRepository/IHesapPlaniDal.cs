using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.HesapPlaniRepository
{
    public interface IHesapPlaniDal : IEntityRepository<HesapPlani>
    {
        List<MizanDto> GetTarihAralikliMizan(DateTime tarih1, DateTime tarih2);
        List<MizanDto> GetKasaList();
    }
}
