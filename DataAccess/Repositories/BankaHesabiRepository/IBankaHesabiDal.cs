using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Repositories.BankaHesabiRepository
{
    public interface IBankaHesabiDal : IEntityRepository<BankaHesabi>
    {
        List<BankaHesabiListDto> GetBankaHesabiList();
    }
}
