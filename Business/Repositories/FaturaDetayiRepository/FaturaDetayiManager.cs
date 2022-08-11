using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.FaturaDetayiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.FaturaDetayiRepository.Validation;
using Business.Repositories.FaturaDetayiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.FaturaDetayiRepository;

namespace Business.Repositories.FaturaDetayiRepository
{
    public class FaturaDetayiManager : IFaturaDetayiService
    {
        private readonly IFaturaDetayiDal _faturaDetayiDal;

        public FaturaDetayiManager(IFaturaDetayiDal faturaDetayiDal)
        {
            _faturaDetayiDal = faturaDetayiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FaturaDetayiValidator))]
        [RemoveCacheAspect("IFaturaDetayiService.Get")]

        public async Task<IResult> Add(FaturaDetayi faturaDetayi)
        {
            await _faturaDetayiDal.Add(faturaDetayi);
            return new SuccessResult(FaturaDetayiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FaturaDetayiValidator))]
        [RemoveCacheAspect("IFaturaDetayiService.Get")]

        public async Task<IResult> Update(FaturaDetayi faturaDetayi)
        {
            await _faturaDetayiDal.Update(faturaDetayi);
            return new SuccessResult(FaturaDetayiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IFaturaDetayiService.Get")]

        public async Task<IResult> Delete(FaturaDetayi faturaDetayi)
        {
            await _faturaDetayiDal.Delete(faturaDetayi);
            return new SuccessResult(FaturaDetayiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<FaturaDetayi>>> GetList()
        {
            return new SuccessDataResult<List<FaturaDetayi>>(await _faturaDetayiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<FaturaDetayi>> GetById(int id)
        {
            return new SuccessDataResult<FaturaDetayi>(await _faturaDetayiDal.Get(p => p.Id == id));
        }

    }
}
