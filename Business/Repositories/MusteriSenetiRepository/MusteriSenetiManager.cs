using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.MusteriSenetiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.MusteriSenetiRepository.Validation;
using Business.Repositories.MusteriSenetiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.MusteriSenetiRepository;

namespace Business.Repositories.MusteriSenetiRepository
{
    public class MusteriSenetiManager : IMusteriSenetiService
    {
        private readonly IMusteriSenetiDal _musteriSenetiDal;

        public MusteriSenetiManager(IMusteriSenetiDal musteriSenetiDal)
        {
            _musteriSenetiDal = musteriSenetiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(MusteriSenetiValidator))]
        [RemoveCacheAspect("IMusteriSenetiService.Get")]

        public async Task<IResult> Add(MusteriSeneti musteriSeneti)
        {
            await _musteriSenetiDal.Add(musteriSeneti);
            return new SuccessResult(MusteriSenetiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(MusteriSenetiValidator))]
        [RemoveCacheAspect("IMusteriSenetiService.Get")]

        public async Task<IResult> Update(MusteriSeneti musteriSeneti)
        {
            await _musteriSenetiDal.Update(musteriSeneti);
            return new SuccessResult(MusteriSenetiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IMusteriSenetiService.Get")]

        public async Task<IResult> Delete(MusteriSeneti musteriSeneti)
        {
            await _musteriSenetiDal.Delete(musteriSeneti);
            return new SuccessResult(MusteriSenetiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<MusteriSeneti>>> GetList()
        {
            return new SuccessDataResult<List<MusteriSeneti>>(await _musteriSenetiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<MusteriSeneti>> GetById(int id)
        {
            return new SuccessDataResult<MusteriSeneti>(await _musteriSenetiDal.Get(p => p.Id == id));
        }

    }
}
