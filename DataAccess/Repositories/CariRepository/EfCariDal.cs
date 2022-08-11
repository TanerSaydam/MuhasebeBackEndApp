using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CariRepository;
using DataAccess.Context.EntityFramework;
using Entities.Dtos;

namespace DataAccess.Repositories.CariRepository
{
    public class EfCariDal : EfEntityRepositoryBase<Cari, SimpleContextDb>, ICariDal
    {
        public List<CariListDto> GetCariList()
        {
            using (var context = new SimpleContextDb())
            {
                var result = from cari in context.Caris
                             join hesapPlani in context.HesapPlanis on cari.HesapPlaniId equals hesapPlani.Id
                             select new CariListDto
                             {
                                 Id = cari.Id,
                                 HesapPlaniId = cari.HesapPlaniId,
                                 Adres = cari.Adres,
                                 CariAdi = hesapPlani.HesapAdi,
                                 HesapPlaniKodu = hesapPlani.HesapKodu,
                                 TCNumarasi = cari.TCNumarasi,
                                 Mail = cari.Mail,
                                 VergiDairesi = cari.VergiDairesi,
                                 VergiNumarasi = cari.VergiNumarasi,
                                 Telefon = cari.Telefon,
                                 Borc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.Borc),
                                 Alacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.Alacak),
                                 USDBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.USDBorc),
                                 USDAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.USDAlacak),
                                 EuroBorc = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.EuroBorc),
                                 EuroAlacak = context.YevmiyeFisis.Where(p => p.HesapPlaniId == cari.HesapPlaniId).Sum(s => s.EuroAlacak)
                             };

                return result.OrderBy(p => p.CariAdi).ToList();
            }
        }
    }
}
