using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CariRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CariRepository.Validation;
using Business.Repositories.CariRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CariRepository;
using Entities.Dtos;
using Business.Repositories.HesapPlaniRepository;
using AutoMapper;
using Business.Repositories.YevmiyeFisiRepository;
using Core.Utilities.Business;

namespace Business.Repositories.CariRepository
{
    public class CariManager : ICariService
    {
        private readonly ICariDal _cariDal;
        private readonly IHesapPlaniService _hesapPlaniService;
        private readonly IYevmiyeFisiService _yevmiyeFisiService;


        public CariManager(ICariDal cariDal, IHesapPlaniService hesapPlaniService, IYevmiyeFisiService yevmiyeFisiService)
        {
            _cariDal = cariDal;
            _hesapPlaniService = hesapPlaniService;
            _yevmiyeFisiService = yevmiyeFisiService;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CariValidator))]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Add(CariDto cariDto)
        {
            HesapPlani hesapPlani = new()
            {
                Id = 0,
                HesapAdi = cariDto.CariAdi,
                HesapKodu = cariDto.HesapPlaniKodu,
                HesapTuru = "M"
            };

            var result = await _hesapPlaniService.Add(hesapPlani);
            if (!result.Success)
            {
                return result;
            }

            Cari cari = new()
            {
                Id = 0,
                HesapPlaniId = hesapPlani.Id,
                Adres = cariDto.Adres,
                Mail = cariDto.Mail,
                TCNumarasi = cariDto.TCNumarasi,
                Telefon = cariDto.Telefon,
                VergiDairesi = cariDto.VergiDairesi,
                VergiNumarasi = cariDto.VergiNumarasi
            };

            await _cariDal.Add(cari);
            return new SuccessResult(CariMessages.Added);
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(CariValidator))]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Update(CariDto cariDto)
        {
            var cari = await _cariDal.Get(p => p.Id == cariDto.Id);
            var hesapPlani = await _hesapPlaniService.GetById(cari.HesapPlaniId);
            if (hesapPlani.Data.HesapKodu != cariDto.HesapPlaniKodu) 
            { 
                hesapPlani.Data.HesapKodu = cariDto.HesapPlaniKodu;
                var result = await _hesapPlaniService.Update(hesapPlani.Data);
                if (!result.Success)
                    return result;
            };

            if (hesapPlani.Data.HesapAdi != cariDto.CariAdi)
            {
                hesapPlani.Data.HesapAdi = cariDto.CariAdi;
                var result = await _hesapPlaniService.Update(hesapPlani.Data);
                if (!result.Success)
                    return result;
            };

            Cari updateCari = new()
            {
                Id = cariDto.Id,
                HesapPlaniId = hesapPlani.Data.Id,
                Adres = cariDto.Adres,
                Mail = cariDto.Mail,
                TCNumarasi = cariDto.TCNumarasi,
                Telefon = cariDto.Telefon,
                VergiDairesi = cariDto.VergiDairesi,
                VergiNumarasi = cariDto.VergiNumarasi
            };

            await _cariDal.Update(cari);
            return new SuccessResult(CariMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("ICariService.Get")]

        public async Task<IResult> Delete(int cariId)
        {
            var cari = await _cariDal.Get(p => p.Id == cariId);
            var result = BusinessRules.Run(CariYevmiyeKayitiniKontrolEt(cari.HesapPlaniId));
            if (result != null)
            {
                return result;
            }            

            await _cariDal.Delete(cari);
            await _hesapPlaniService.Delete(cari.HesapPlaniId);
            return new SuccessResult(CariMessages.Deleted);
        }

        public IResult CariYevmiyeKayitiniKontrolEt(int hesapPlaniId)
        {
            string tarih1 = "01.01." + DateTime.Now.Year.ToString();
            string tarih2 = "31.12." + DateTime.Now.Year.ToString();

            var result = _yevmiyeFisiService.GetYevmiyeFisiWithHesapPlaniId(hesapPlaniId, tarih1, tarih2);
            if (result.Data.Count > 0)
            {
                return new ErrorResult("Hareket kaydý olan cariler silinemez!");
            }
            return new SuccessResult();
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Cari>>> GetList()
        {
            return new SuccessDataResult<List<Cari>>(await _cariDal.GetAll());
        }
        
        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public IDataResult<List<CariListDto>> GetCariList()
        {
            return new SuccessDataResult<List<CariListDto>>(_cariDal.GetCariList());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Cari>> GetById(int id)
        {
            return new SuccessDataResult<Cari>(await _cariDal.Get(p => p.Id == id));
        }

    }
}
