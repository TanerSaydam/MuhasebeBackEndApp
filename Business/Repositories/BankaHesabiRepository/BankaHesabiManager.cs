using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.BankaHesabiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.BankaHesabiRepository.Validation;
using Business.Repositories.BankaHesabiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BankaHesabiRepository;
using Entities.Dtos;
using Business.Repositories.HesapPlaniRepository;
using Core.Utilities.Business;
using Business.Repositories.YevmiyeFisiRepository;

namespace Business.Repositories.BankaHesabiRepository
{
    public class BankaHesabiManager : IBankaHesabiService
    {
        private readonly IBankaHesabiDal _bankaHesabiDal;
        private readonly IHesapPlaniService _hesapPlaniService;
        private readonly IYevmiyeFisiService _yevmiyeFisiService;

        public BankaHesabiManager(IBankaHesabiDal bankaHesabiDal, IHesapPlaniService hesapPlaniService, IYevmiyeFisiService yevmiyeFisiService)
        {
            _bankaHesabiDal = bankaHesabiDal;
            _hesapPlaniService = hesapPlaniService;
            _yevmiyeFisiService = yevmiyeFisiService;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BankaHesabiValidator))]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Add(BankaHesabiDto bankaHesabiDto)
        {
            var result = BusinessRules.Run(
                HesaPlaniKodu102IlemiBasliyor(bankaHesabiDto.HesapPlaniKodu),
                await HesapPlaniKoduMevcutMu(bankaHesabiDto.HesapPlaniKodu)
                );
            if (result != null)
            {
                return result;
            }

            HesapPlani hesapPlani = new()
            {
                Id = 0,
                HesapAdi = bankaHesabiDto.HesapPlaniAdi,
                HesapKodu = bankaHesabiDto.HesapPlaniKodu,
                HesapTuru = "M"
            };

            result = await _hesapPlaniService.Add(hesapPlani);
            if (!result.Success)
            {
                return result;
            }

            BankaHesabi bankaHesabi = new BankaHesabi()
            {
                Id = 0,
                BankaAdi = bankaHesabiDto.BankaAdi,
                HesapNumarasi = bankaHesabiDto.HesapNumarasi,
                HesapPlaniId = hesapPlani.Id,
                IBAN = bankaHesabiDto.IBAN
            };

            await _bankaHesabiDal.Add(bankaHesabi);
            return new SuccessResult(BankaHesabiMessages.Added);
        }

        public IResult HesaPlaniKodu102IlemiBasliyor(string HesapPlaniKodu)
        {
            if (!HesapPlaniKodu.StartsWith("102"))
            {
                return new ErrorResult("Banka hesap planý kodu 102 ile baþlamalýdýr!");
            }
            return new SuccessResult();
        }

        public async Task<IResult> HesapPlaniKoduMevcutMu(string hesapPlaniKodu)
        {
            return await _hesapPlaniService.HesapPlaniKoduVarMiKontrolEt(hesapPlaniKodu);
        }


        //[SecuredAspect()]
        [ValidationAspect(typeof(BankaHesabiValidator))]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Update(BankaHesabiDto bankaHesabiDto)
        {
            var banka = await _bankaHesabiDal.Get(p => p.Id == bankaHesabiDto.Id);
            var hesapPlani = await _hesapPlaniService.GetById(banka.HesapPlaniId);
            if (hesapPlani.Data.HesapKodu != bankaHesabiDto.HesapPlaniKodu)
            {
                var kontrol = HesaPlaniKodu102IlemiBasliyor(bankaHesabiDto.HesapPlaniKodu);
                if (kontrol != null)
                {
                    return kontrol;
                }

                hesapPlani.Data.HesapKodu = bankaHesabiDto.HesapPlaniKodu;
                var result = await _hesapPlaniService.Update(hesapPlani.Data);
                if (!result.Success)
                    return result;
            };

            if (hesapPlani.Data.HesapAdi != bankaHesabiDto.HesapPlaniAdi)
            {
                hesapPlani.Data.HesapAdi = bankaHesabiDto.HesapPlaniAdi;
                var result = await _hesapPlaniService.Update(hesapPlani.Data);
                if (!result.Success)
                    return result;
            };

            BankaHesabi bankaHesabi = new BankaHesabi()
            {
                Id = bankaHesabiDto.Id,
                BankaAdi = bankaHesabiDto.BankaAdi,
                HesapNumarasi = bankaHesabiDto.HesapNumarasi,
                HesapPlaniId = hesapPlani.Data.Id,
                IBAN = bankaHesabiDto.IBAN
            };

            await _bankaHesabiDal.Update(bankaHesabi);
            return new SuccessResult(BankaHesabiMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IBankaHesabiService.Get")]

        public async Task<IResult> Delete(int bankaHesabiId)
        {
            var banka = await _bankaHesabiDal.Get(p => p.Id == bankaHesabiId);
            var result = BusinessRules.Run(BankaYevmiyeKayitiniKontrolEt(banka.HesapPlaniId));
            if (result != null)
            {
                return result;
            }            
                        
            await _bankaHesabiDal.Delete(banka);
            await _hesapPlaniService.Delete(banka.HesapPlaniId);

            return new SuccessResult(BankaHesabiMessages.Deleted);
        }

        public IResult BankaYevmiyeKayitiniKontrolEt(int hesapPlaniId)
        {
            string tarih1 = "01.01." + DateTime.Now.Year.ToString();
            string tarih2 = "31.12." + DateTime.Now.Year.ToString();

            var result = _yevmiyeFisiService.GetYevmiyeFisiWithHesapPlaniId(hesapPlaniId, tarih1, tarih2);
            if (result.Data.Count > 0)
            {
                return new ErrorResult("Hareket kaydý olan banka hesabý silinemez!");
            }
            return new SuccessResult();
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<BankaHesabi>>> GetList()
        {
            return new SuccessDataResult<List<BankaHesabi>>(await _bankaHesabiDal.GetAll());
        }
        
        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public IDataResult<List<BankaHesabiListDto>> GetBankaHesabiList()
        {
            return new SuccessDataResult<List<BankaHesabiListDto>>(_bankaHesabiDal.GetBankaHesabiList());
        }

        [SecuredAspect()]
        public async Task<IDataResult<BankaHesabi>> GetById(int id)
        {
            return new SuccessDataResult<BankaHesabi>(await _bankaHesabiDal.Get(p => p.Id == id));
        }

    }
}
