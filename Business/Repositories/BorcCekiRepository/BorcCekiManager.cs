using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.BorcCekiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.BorcCekiRepository.Validation;
using Business.Repositories.BorcCekiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BorcCekiRepository;
using Business.Repositories.YevmiyeFisiRepository;
using Entities.Dtos;
using Business.Repositories.CekSenetMuhasebeKoduRepository;
using Core.Utilities.Business;
using Business.Repositories.BorcCekiHareketRepository;

namespace Business.Repositories.BorcCekiRepository
{
    public class BorcCekiManager : IBorcCekiService
    {
        private readonly IBorcCekiDal _borcCekiDal;
        private readonly IYevmiyeFisiService _yevmiyeFisiService;
        private readonly ICekSenetMuhasebeKoduService _cekSenetMuhasebeKoduService;
        private readonly IBorcCekiHareketService _borcCekiHareketService;

        public BorcCekiManager(IBorcCekiDal borcCekiDal, IYevmiyeFisiService yevmiyeFisiService, ICekSenetMuhasebeKoduService cekSenetMuhasebeKoduService, IBorcCekiHareketService borcCekiHareketService)
        {
            _borcCekiDal = borcCekiDal;
            _yevmiyeFisiService = yevmiyeFisiService;
            _cekSenetMuhasebeKoduService = cekSenetMuhasebeKoduService;
            _borcCekiHareketService = borcCekiHareketService;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BorcCekiValidator))]
        [RemoveCacheAspect("IBorcCekiService.Get")]
        

        public async Task<IResult> Add(BorcCeki borcCeki, int verilenFirmaId)
        {
            var result = BusinessRules.Run(
                await CekSeriNumarasiKullanilmisMi(borcCeki.SeriNo));
            if (result != null)
                return result;

            var cekSenetMuhasebeKodu = await _cekSenetMuhasebeKoduService.Get();

            if (cekSenetMuhasebeKodu.Data == null)
            {
                return new ErrorResult(BorcCekiMessages.CannotFindMuhasebeKodu);
            }

            ModulYevmiyeFisiDto yevmiyeFisi = new()
            {
                Tarih = borcCeki.Tarih,
                Aciklama = "Borç Çeki Kaydý",
                BorcAlacak = "Alacak",
                HesapPlaniId = cekSenetMuhasebeKodu.Data.BorcCekiHesapPlaniId,                
                TLTutar = borcCeki.Tutar,
                EuroTutar = borcCeki.EuroTutar,
                USDTutar = borcCeki.USDTutar,
                ToHesapPlaniId = verilenFirmaId
            };

            await _borcCekiDal.Add(borcCeki);
            var yevmiyeFisiResult = await _yevmiyeFisiService.ModulAdd(yevmiyeFisi);

            BorcCekiHareket borcCekiHareket = new()
            {
                Id = 0,
                BorcCekiId = borcCeki.Id,
                HesapPlaniId = verilenFirmaId,
                Aciklama = "Firmaya Verilen Borç Çeki",
                Tarih = borcCeki.Tarih,
                YevmiyeFisiNumarasi = yevmiyeFisiResult.Data.YevmiyeFisNumarasi,
            };

            await _borcCekiHareketService.Add(borcCekiHareket);

            return new SuccessResult(BorcCekiMessages.Added);
        }

        public async Task<IResult> CekSeriNumarasiKullanilmisMi(string seriNo)
        {
            var result = await _borcCekiDal.Get(p => p.SeriNo == seriNo);
            if (result != null)
            {
                return new ErrorResult("Bu çek numarasý daha önce kullanýlmýþ!");
            }
            return new SuccessResult();
        }        

        //[SecuredAspect()]
        [RemoveCacheAspect("IBorcCekiService.Get")]

        public async Task<IResult> Delete(BorcCeki borcCeki)
        {
            await _borcCekiDal.Delete(borcCeki);
            return new SuccessResult(BorcCekiMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<BorcCeki>>> GetList()
        {
            return new SuccessDataResult<List<BorcCeki>>(await _borcCekiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<BorcCeki>> GetById(int id)
        {
            return new SuccessDataResult<BorcCeki>(await _borcCekiDal.Get(p => p.Id == id));
        }

    }
}
