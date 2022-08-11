using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.StokRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.StokRepository.Validation;
using Business.Repositories.StokRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.StokRepository;

namespace Business.Repositories.StokRepository
{
    public class StokManager : IStokService
    {
        private readonly IStokDal _stokDal;

        public StokManager(IStokDal stokDal)
        {
            _stokDal = stokDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokValidator))]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Add(Stok stok)
        {
            await _stokDal.Add(stok);
            return new SuccessResult(StokMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(StokValidator))]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Update(Stok stok)
        {
            await _stokDal.Update(stok);
            return new SuccessResult(StokMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IStokService.Get")]

        public async Task<IResult> Delete(Stok stok)
        {
            await _stokDal.Delete(stok);
            return new SuccessResult(StokMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Stok>>> GetList()
        {
            return new SuccessDataResult<List<Stok>>(await _stokDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Stok>> GetById(int id)
        {
            return new SuccessDataResult<Stok>(await _stokDal.Get(p => p.Id == id));
        }

    }
}
