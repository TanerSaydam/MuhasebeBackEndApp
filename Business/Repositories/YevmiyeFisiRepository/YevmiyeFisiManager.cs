using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.YevmiyeFisiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.YevmiyeFisiRepository.Validation;
using Business.Repositories.YevmiyeFisiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.YevmiyeFisiRepository;
using Entities.Dtos;

namespace Business.Repositories.YevmiyeFisiRepository
{
    public class YevmiyeFisiManager : IYevmiyeFisiService
    {
        private readonly IYevmiyeFisiDal _yevmiyeFisiDal;

        public YevmiyeFisiManager(IYevmiyeFisiDal yevmiyeFisiDal)
        {
            _yevmiyeFisiDal = yevmiyeFisiDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(YevmiyeFisiValidator))]
        [RemoveCacheAspect("IYevmiyeFisiService.Get")]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Add(YevmiyeFisi yevmiyeFisi)
        {
            if (yevmiyeFisi.YevmiyeFisNumarasi == "" || yevmiyeFisi.YevmiyeFisNumarasi == null)
            {
                string yevmiyeFisiNumarasi = await SetNewYevmiyeFisiNumarasi();
                yevmiyeFisi.YevmiyeFisNumarasi = yevmiyeFisiNumarasi;
            }

            await _yevmiyeFisiDal.Add(yevmiyeFisi);
            return new SuccessResult(YevmiyeFisiMessages.Added);
        }
        
        //[SecuredAspect()]
        [ValidationAspect(typeof(YevmiyeFisiValidator))]
        [RemoveCacheAspect("IYevmiyeFisiService.Get")]
        [RemoveCacheAspect("ICariService.Get")]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IDataResult<YevmiyeFisi>> ModulAdd(ModulYevmiyeFisiDto modulYevmiyeFisiDto)
        {
            string yevmiyeFisiNumarasi = await SetNewYevmiyeFisiNumarasi();

            YevmiyeFisi yevmiyeFisi1 = new YevmiyeFisi();
            yevmiyeFisi1.Id = 0;
            yevmiyeFisi1.Aciklama = modulYevmiyeFisiDto.Aciklama;
            yevmiyeFisi1.YevmiyeFisNumarasi = yevmiyeFisiNumarasi;
            yevmiyeFisi1.Tarih = modulYevmiyeFisiDto.Tarih;
            yevmiyeFisi1.HesapPlaniId = modulYevmiyeFisiDto.HesapPlaniId;
            if (modulYevmiyeFisiDto.BorcAlacak == "Borç")
            {
                yevmiyeFisi1.Borc = modulYevmiyeFisiDto.TLTutar;
                yevmiyeFisi1.Alacak = 0;
                yevmiyeFisi1.USDBorc = modulYevmiyeFisiDto.USDTutar;
                yevmiyeFisi1.USDAlacak = 0;
                yevmiyeFisi1.EuroBorc = modulYevmiyeFisiDto.EuroTutar;
                yevmiyeFisi1.EuroAlacak = 0;
            }
            else
            {
                yevmiyeFisi1.Borc = 0;
                yevmiyeFisi1.Alacak = modulYevmiyeFisiDto.TLTutar;
                yevmiyeFisi1.USDBorc = 0;
                yevmiyeFisi1.USDAlacak = modulYevmiyeFisiDto.USDTutar;
                yevmiyeFisi1.EuroBorc = 0;
                yevmiyeFisi1.EuroAlacak = modulYevmiyeFisiDto.EuroTutar;
            }
            await _yevmiyeFisiDal.Add(yevmiyeFisi1);

            YevmiyeFisi yevmiyeFisi2 = new YevmiyeFisi();
            yevmiyeFisi2.Id = 0;
            yevmiyeFisi2.Aciklama = modulYevmiyeFisiDto.Aciklama;
            yevmiyeFisi2.YevmiyeFisNumarasi = yevmiyeFisiNumarasi;
            yevmiyeFisi2.Tarih = modulYevmiyeFisiDto.Tarih;
            yevmiyeFisi2.HesapPlaniId = modulYevmiyeFisiDto.ToHesapPlaniId;
            if (modulYevmiyeFisiDto.BorcAlacak == "Alacak")
            {
                yevmiyeFisi2.Borc = modulYevmiyeFisiDto.TLTutar;
                yevmiyeFisi2.Alacak = 0;
                yevmiyeFisi2.USDBorc = modulYevmiyeFisiDto.USDTutar;
                yevmiyeFisi2.USDAlacak = 0;
                yevmiyeFisi2.EuroBorc = modulYevmiyeFisiDto.EuroTutar;
                yevmiyeFisi2.EuroAlacak = 0;
            }
            else
            {
                yevmiyeFisi2.Borc = 0;
                yevmiyeFisi2.Alacak = modulYevmiyeFisiDto.TLTutar;
                yevmiyeFisi2.USDBorc = 0;
                yevmiyeFisi2.USDAlacak = modulYevmiyeFisiDto.USDTutar;
                yevmiyeFisi2.EuroBorc = 0;
                yevmiyeFisi2.EuroAlacak = modulYevmiyeFisiDto.EuroTutar;
            }
            await _yevmiyeFisiDal.Add(yevmiyeFisi2);

            return new SuccessDataResult<YevmiyeFisi>(yevmiyeFisi1, YevmiyeFisiMessages.Added);
        }

        public async Task<string> SetNewYevmiyeFisiNumarasi()
        {
            var sonYevmiyeFisi =  await _yevmiyeFisiDal.GetLastYevmiyeFisiNumarasi();
            if (sonYevmiyeFisi == null)
            {
                return "0000000000000001";
                //2
            }

            string sonNumara = sonYevmiyeFisi.YevmiyeFisNumarasi;
            int numara = Convert.ToInt16(sonNumara) + 1;
            int numaraUzunlugu = numara.ToString().Length;

            string yeniNumara = numara.ToString();

            for (int i = numaraUzunlugu; i < 16; i++)
            {
                yeniNumara = "0" + yeniNumara;
            }

            return yeniNumara;
        }


        [SecuredAspect()]
        [ValidationAspect(typeof(YevmiyeFisiValidator))]
        [RemoveCacheAspect("IYevmiyeFisiService.Get")]
        [RemoveCacheAspect("ICariService.Get")]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Update(YevmiyeFisi yevmiyeFisi)
        {
            await _yevmiyeFisiDal.Update(yevmiyeFisi);
            return new SuccessResult(YevmiyeFisiMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IYevmiyeFisiService.Get")]
        [RemoveCacheAspect("ICariService.Get")]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Delete(YevmiyeFisi yevmiyeFisi)
        {
            await _yevmiyeFisiDal.Delete(yevmiyeFisi);
            return new SuccessResult(YevmiyeFisiMessages.Deleted);
        }
        
        //[SecuredAspect()]
        [RemoveCacheAspect("IYevmiyeFisiService.Get")]
        [RemoveCacheAspect("ICariService.Get")]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> DeleteWithYevmiyeFisiNumarasi(string yevmiyeFisiNumarasi)
        {
            var result = await _yevmiyeFisiDal.GetAll(p => p.YevmiyeFisNumarasi == yevmiyeFisiNumarasi);

            if (result.Count == 0)
            {
                return new ErrorResult(YevmiyeFisiMessages.CannotFindYevmiyeFisi);
            }

            foreach (var item in result)
            {
                await _yevmiyeFisiDal.Delete(item);
            }
            
            return new SuccessResult(YevmiyeFisiMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<YevmiyeFisi>>> GetList()
        {
            return new SuccessDataResult<List<YevmiyeFisi>>(await _yevmiyeFisiDal.GetAll());
        }

        public IDataResult<List<YevmiyeFisiDto>> GetYevmiyeFisiWithHesapPlaniId(int hesapPlaniId, string tarih1, string tarih2)
        {
            if (tarih1 == null || tarih1 == "")
            {
                tarih1 = "01.01." + DateTime.Now.Year.ToString();
            }

            if (tarih2 == null || tarih2 == "")
            {
                tarih2 = "31.12." + DateTime.Now.Year.ToString();
            }

            return new SuccessDataResult<List<YevmiyeFisiDto>>(_yevmiyeFisiDal.GetYevmiyeFisiWithHesapPlaniId(hesapPlaniId, Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2)));
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public IDataResult<List<YevmiyeFisiListDto>> GetYevmiyeFisiList(string tarih1, string tarih2)
        {
            if (tarih1 == null || tarih1 == "")
            {
                tarih1 = "01.01." + DateTime.Now.Year.ToString();
            }

            if (tarih2 == null || tarih2 == "")
            {
                tarih2 = "31.12." + DateTime.Now.Year.ToString();
            }

            return new SuccessDataResult<List<YevmiyeFisiListDto>>(_yevmiyeFisiDal.GetYevmiyeFisiList(Convert.ToDateTime(tarih1), Convert.ToDateTime(tarih2)));
        }

        [SecuredAspect()]
        public async Task<IDataResult<YevmiyeFisi>> GetById(int id)
        {
            return new SuccessDataResult<YevmiyeFisi>(await _yevmiyeFisiDal.Get(p => p.Id == id));
        }

    }
}
