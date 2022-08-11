using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.FaturaRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.FaturaRepository.Validation;
using Business.Repositories.FaturaRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.FaturaRepository;

namespace Business.Repositories.FaturaRepository
{
    public class FaturaManager : IFaturaService
    {
        private readonly IFaturaDal _faturaDal;

        public FaturaManager(IFaturaDal faturaDal)
        {
            _faturaDal = faturaDal;
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FaturaValidator))]
        [RemoveCacheAspect("IFaturaService.Get")]

        public async Task<IResult> Add(Fatura fatura)
        {
            await _faturaDal.Add(fatura);
            return new SuccessResult(FaturaMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(FaturaValidator))]
        [RemoveCacheAspect("IFaturaService.Get")]

        public async Task<IResult> Update(Fatura fatura)
        {
            await _faturaDal.Update(fatura);
            return new SuccessResult(FaturaMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IFaturaService.Get")]

        public async Task<IResult> Delete(Fatura fatura)
        {
            await _faturaDal.Delete(fatura);
            return new SuccessResult(FaturaMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<Fatura>>> GetList()
        {
            return new SuccessDataResult<List<Fatura>>(await _faturaDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<Fatura>> GetById(int id)
        {
            return new SuccessDataResult<Fatura>(await _faturaDal.Get(p => p.Id == id));
        }

    }
}
