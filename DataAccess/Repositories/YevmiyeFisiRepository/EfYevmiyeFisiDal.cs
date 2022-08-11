using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.YevmiyeFisiRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.YevmiyeFisiRepository
{
    public class EfYevmiyeFisiDal : EfEntityRepositoryBase<YevmiyeFisi, SimpleContextDb>, IYevmiyeFisiDal
    {
        public async Task<YevmiyeFisi> GetLastYevmiyeFisiNumarasi()
        {
            using (var context = new SimpleContextDb())
            {
                var result = await context.YevmiyeFisis.OrderBy(o=> o.YevmiyeFisNumarasi).LastOrDefaultAsync();
                return result;
            }
        }

        public List<YevmiyeFisiListDto> GetYevmiyeFisiList(DateTime tarih1, DateTime tarih2)
        {
            using (var context = new SimpleContextDb())
            {
                var yevmiyeFisiList = context.YevmiyeFisis.Where(p => p.Tarih >= tarih1 && p.Tarih <= tarih2)
                   .GroupBy(p => p.YevmiyeFisNumarasi)
                   .Select(p => p.First())
                   .ToList();

                var result = from x in yevmiyeFisiList
                             join hesapPlani in context.HesapPlanis on x.HesapPlaniId equals hesapPlani.Id
                             select new YevmiyeFisiListDto
                             {
                                 Id = x.Id,
                                 YevmiyeFisNumarasi = x.YevmiyeFisNumarasi,
                                 Tarih = x.Tarih,
                                 HesapPlaniId = x.HesapPlaniId,
                                 Aciklama = x.Aciklama,
                                 HesapPlaniKodu = hesapPlani.HesapKodu,
                                 HesapPlaniAdi = hesapPlani.HesapAdi,
                                 Borc = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.Borc),
                                 Alacak = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.Alacak),
                                 USDBorc = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.USDBorc),
                                 USDAlacak = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.USDAlacak),
                                 EuroBorc = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.EuroBorc),
                                 EuroAlacak = context.YevmiyeFisis.Where(p => p.YevmiyeFisNumarasi == x.YevmiyeFisNumarasi).Sum(s => s.EuroAlacak)
                             };

                return result.OrderByDescending(s=> s.Tarih).ToList();
            }
        }

        public List<YevmiyeFisiDto> GetYevmiyeFisiWithHesapPlaniId(int hesapPlaniId, DateTime tarih1, DateTime tarih2)
        {
            using (var context = new SimpleContextDb())
            {
                var result = from yevmiyeFisi in context.YevmiyeFisis.Where(p=> p.Tarih >= tarih1 && p.Tarih <= tarih2 && p.HesapPlaniId == hesapPlaniId)
                             join hesapPlani in context.HesapPlanis on yevmiyeFisi.HesapPlaniId equals hesapPlani.Id
                             select new YevmiyeFisiDto
                             {
                                 Id = yevmiyeFisi.Id,
                                 Aciklama = yevmiyeFisi.Aciklama,
                                 Alacak = yevmiyeFisi.Alacak,
                                 Borc = yevmiyeFisi.Borc,
                                 EuroAlacak = yevmiyeFisi.EuroAlacak,
                                 EuroBorc = yevmiyeFisi.EuroBorc,
                                 HesapPlaniAdi = hesapPlani.HesapAdi,
                                 HesapPlaniKodu = hesapPlani.HesapKodu,
                                 HesapPlaniId = yevmiyeFisi.HesapPlaniId,
                                 Tarih = yevmiyeFisi.Tarih,
                                 USDAlacak = yevmiyeFisi.USDAlacak,
                                 USDBorc = yevmiyeFisi.USDBorc,
                                 YevmiyeFisNumarasi = yevmiyeFisi.YevmiyeFisNumarasi
                             };
                return result.ToList();
            }
        }
    }
}
