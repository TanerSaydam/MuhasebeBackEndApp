using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.BorcSenetiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.BorcSenetiRepository.Validation;
using Business.Repositories.BorcSenetiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.BorcSenetiRepository;

namespace Business.Repositories.BorcSenetiRepository
{
    public class BorcSenetiManager : IBorcSenetiService
    {
        private readonly IBorcSenetiDal _borcSenetiDal;

        public BorcSenetiManager(IBorcSenetiDal borcSenetiDal)
        {
            _borcSenetiDal = borcSenetiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(BorcSenetiValidator))]
        [RemoveCacheAspect("IBorcSenetiService.Get")]

        public async Task<IResult> Add(BorcSeneti borcSeneti)
        {
            await _borcSenetiDal.Add(borcSeneti);
            return new SuccessResult(BorcSenetiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(BorcSenetiValidator))]
        [RemoveCacheAspect("IBorcSenetiService.Get")]

        public async Task<IResult> Update(BorcSeneti borcSeneti)
        {
            await _borcSenetiDal.Update(borcSeneti);
            return new SuccessResult(BorcSenetiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IBorcSenetiService.Get")]

        public async Task<IResult> Delete(BorcSeneti borcSeneti)
        {
            await _borcSenetiDal.Delete(borcSeneti);
            return new SuccessResult(BorcSenetiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<BorcSeneti>>> GetList()
        {
            return new SuccessDataResult<List<BorcSeneti>>(await _borcSenetiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<BorcSeneti>> GetById(int id)
        {
            return new SuccessDataResult<BorcSeneti>(await _borcSenetiDal.Get(p => p.Id == id));
        }

    }
}
