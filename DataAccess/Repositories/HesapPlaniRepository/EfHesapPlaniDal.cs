using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.HesapPlaniRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.HesapPlaniRepository
{
    public class EfHesapPlaniDal : EfEntityRepositoryBase<HesapPlani, SimpleContextDb>, IHesapPlaniDal
    {
        public List<MizanDto> GetTarihAralikliMizan(DateTime tarih1, DateTime tarih2)
        {
            using (var context = new SimpleContextDb())
            {                
                var result = from hesapPlani in context.HesapPlanis
                             select new MizanDto
                             {
                                 Id = hesapPlani.Id,
                                 HesapAdi = hesapPlani.HesapAdi,
                                 HesapKodu = hesapPlani.HesapKodu,
                                 HesapTuru = hesapPlani.HesapTuru,
                                 Borc = context.YevmiyeFisis.Where(p => p.Tarih >= tarih1 && p.Tarih <= tarih2 && p.HesapPlaniId == hesapPlani.Id).Sum(s => s.Borc),
                                 Alacak = context.YevmiyeFisis.Where(p => p.Tarih >= tarih1 && p.Tarih <= tarih2 && p.HesapPlaniId == hesapPlani.Id).Sum(s => s.Alacak),
                             };

                return result.OrderBy(p=> p.HesapKodu).ToList();
            }
        }
        
        public List<MizanDto> GetKasaList()
        {
            using (var context = new SimpleContextDb())
            {                
                var result = from hesapPlani in context.HesapPlanis
                             where hesapPlani.HesapKodu.StartsWith("100") && hesapPlani.HesapTuru == "M"
                             select new MizanDto
                             {
                                 Id = hesapPlani.Id,
                                 HesapAdi = hesapPlani.HesapAdi,
                                 HesapKodu = hesapPlani.HesapKodu,
                                 HesapTuru = hesapPlani.HesapTuru,
                                 Borc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.Borc),
                                 Alacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.Alacak),
                                 USDAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.USDAlacak),
                                 USDBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.USDBorc),
                                 EuroBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.EuroBorc),
                                 EuroAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == hesapPlani.Id).Sum(s => s.EuroAlacak),
                             };

                return result.OrderBy(p=> p.HesapKodu).ToList();
            }
        }
    }
}
