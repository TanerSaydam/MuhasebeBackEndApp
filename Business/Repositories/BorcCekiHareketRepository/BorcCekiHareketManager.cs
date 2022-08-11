using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.BorcCekiHareketRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.BorcCekiHareketRepository.Validation;
using Business.Repositories.BorcCekiHareketRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BorcCekiHareketRepository;

namespace Business.Repositories.BorcCekiHareketRepository
{
    public class BorcCekiHareketManager : IBorcCekiHareketService
    {
        private readonly IBorcCekiHareketDal _borcCekiHareketDal;

        public BorcCekiHareketManager(IBorcCekiHareketDal borcCekiHareketDal)
        {
            _borcCekiHareketDal = borcCekiHareketDal;
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BorcCekiHareketValidator))]
        [RemoveCacheAspect("IBorcCekiHareketService.Get")]

        public async Task<IResult> Add(BorcCekiHareket borcCekiHareket)
        {
            await _borcCekiHareketDal.Add(borcCekiHareket);
            return new SuccessResult(BorcCekiHareketMessages.Added);
        }

        //[SecuredAspect()]
        [ValidationAspect(typeof(BorcCekiHareketValidator))]
        [RemoveCacheAspect("IBorcCekiHareketService.Get")]

        public async Task<IResult> Update(BorcCekiHareket borcCekiHareket)
        {
            await _borcCekiHareketDal.Update(borcCekiHareket);
            return new SuccessResult(BorcCekiHareketMessages.Updated);
        }

        //[SecuredAspect()]
        [RemoveCacheAspect("IBorcCekiHareketService.Get")]

        public async Task<IResult> Delete(BorcCekiHareket borcCekiHareket)
        {
            await _borcCekiHareketDal.Delete(borcCekiHareket);
            return new SuccessResult(BorcCekiHareketMessages.Deleted);
        }

        //[SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<BorcCekiHareket>>> GetList()
        {
            return new SuccessDataResult<List<BorcCekiHareket>>(await _borcCekiHareketDal.GetAll());
        }

        //[SecuredAspect()]
        public async Task<IDataResult<BorcCekiHareket>> GetById(int id)
        {
            return new SuccessDataResult<BorcCekiHareket>(await _borcCekiHareketDal.Get(p => p.Id == id));
        }

    }
}
