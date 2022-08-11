using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.BankaHesabiRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;

namespace DataAccess.Repositories.BankaHesabiRepository
{
    public class EfBankaHesabiDal : EfEntityRepositoryBase<BankaHesabi, SimpleContextDb>, IBankaHesabiDal
    {
        public List<BankaHesabiListDto> GetBankaHesabiList()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from banka in context.BankaHesabis
                             join hesapPlani in context.HesapPlanis on banka.HesapPlaniId equals hesapPlani.Id
                             select new BankaHesabiListDto
                             {
                                 Id = banka.Id,  
                                 BankaAdi = banka.BankaAdi,
                                 IBAN = banka.IBAN,
                                 HesapNumarasi = banka.HesapNumarasi,
                                 HesapPlaniAdi = hesapPlani.HesapAdi,
                                 HesapPlaniId = banka.HesapPlaniId,                                 
                                 HesapPlaniKodu = hesapPlani.HesapKodu,                                 
                                 Borc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.Borc),
                                 Alacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.Alacak),
                                 USDBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.USDBorc),
                                 USDAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.USDAlacak),
                                 EuroBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.EuroBorc),
                                 EuroAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == banka.HesapPlaniId).Sum(s => s.EuroAlacak)
                             };

                return result.OrderBy(p => p.HesapPlaniAdi).ToList();
            }
        }
    }
}
