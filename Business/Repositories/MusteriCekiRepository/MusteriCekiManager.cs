using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.MusteriCekiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.MusteriCekiRepository.Validation;
using Business.Repositories.MusteriCekiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.MusteriCekiRepository;

namespace Business.Repositories.MusteriCekiRepository
{
    public class MusteriCekiManager : IMusteriCekiService
    {
        private readonly IMusteriCekiDal _musteriCekiDal;

        public MusteriCekiManager(IMusteriCekiDal musteriCekiDal)
        {
            _musteriCekiDal = musteriCekiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(MusteriCekiValidator))]
        [RemoveCacheAspect("IMusteriCekiService.Get")]

        public async Task<IResult> Add(MusteriCeki musteriCeki)
        {
            await _musteriCekiDal.Add(musteriCeki);
            return new SuccessResult(MusteriCekiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(MusteriCekiValidator))]
        [RemoveCacheAspect("IMusteriCekiService.Get")]

        public async Task<IResult> Update(MusteriCeki musteriCeki)
        {
            await _musteriCekiDal.Update(musteriCeki);
            return new SuccessResult(MusteriCekiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IMusteriCekiService.Get")]

        public async Task<IResult> Delete(MusteriCeki musteriCeki)
        {
            await _musteriCekiDal.Delete(musteriCeki);
            return new SuccessResult(MusteriCekiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<MusteriCeki>>> GetList()
        {
            return new SuccessDataResult<List<MusteriCeki>>(await _musteriCekiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<MusteriCeki>> GetById(int id)
        {
            return new SuccessDataResult<MusteriCeki>(await _musteriCekiDal.Get(p => p.Id == id));
        }

    }
}
