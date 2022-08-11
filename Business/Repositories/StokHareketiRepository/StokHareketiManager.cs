using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StokHareketiRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StokHareketiRepository.Validation;
using Business.Repositories.StokHareketiRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokHareketiRepository;

namespace Business.Repositories.StokHareketiRepository
{
    public class StokHareketiManager : IStokHareketiService
    {
        private readonly IStokHareketiDal _stokHareketiDal;

        public StokHareketiManager(IStokHareketiDal stokHareketiDal)
        {
            _stokHareketiDal = stokHareketiDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketiValidator))]
        [RemoveCacheAspect("IStokHareketiService.Get")]

        public async Task<IResult> Add(StokHareketi stokHareketi)
        {
            await _stokHareketiDal.Add(stokHareketi);
            return new SuccessResult(StokHareketiMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokHareketiValidator))]
        [RemoveCacheAspect("IStokHareketiService.Get")]

        public async Task<IResult> Update(StokHareketi stokHareketi)
        {
            await _stokHareketiDal.Update(stokHareketi);
            return new SuccessResult(StokHareketiMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokHareketiService.Get")]

        public async Task<IResult> Delete(StokHareketi stokHareketi)
        {
            await _stokHareketiDal.Delete(stokHareketi);
            return new SuccessResult(StokHareketiMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<StokHareketi>>> GetList()
        {
            return new SuccessDataResult<List<StokHareketi>>(await _stokHareketiDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<StokHareketi>> GetById(int id)
        {
            return new SuccessDataResult<StokHareketi>(await _stokHareketiDal.Get(p => p.Id == id));
        }

    }
}
