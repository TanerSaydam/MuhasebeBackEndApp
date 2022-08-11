using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CekSenetMuhasebeKoduRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CekSenetMuhasebeKoduRepository.Validation;
using Business.Repositories.CekSenetMuhasebeKoduRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CekSenetMuhasebeKoduRepository;

namespace Business.Repositories.CekSenetMuhasebeKoduRepository
{
    public class CekSenetMuhasebeKoduManager : ICekSenetMuhasebeKoduService
    {
        private readonly ICekSenetMuhasebeKoduDal _cekSenetMuhasebeKoduDal;

        public CekSenetMuhasebeKoduManager(ICekSenetMuhasebeKoduDal cekSenetMuhasebeKoduDal)
        {
            _cekSenetMuhasebeKoduDal = cekSenetMuhasebeKoduDal;
        }        

        //[SecuredAspect()]
        [ValidationAspect(typeof(CekSenetMuhasebeKoduValidator))]
        [RemoveCacheAspect("ICekSenetMuhasebeKoduService.Get")]

        public async Task<IResult> Update(CekSenetMuhasebeKodu cekSenetMuhasebeKodu)
        {
            var result = await _cekSenetMuhasebeKoduDal.GetFirst();
            if (result != null)            
                cekSenetMuhasebeKodu.Id = result.Id;            
            else
                cekSenetMuhasebeKodu.Id = 0;


            if (cekSenetMuhasebeKodu.Id == 0)
                await _cekSenetMuhasebeKoduDal.Add(cekSenetMuhasebeKodu);
            else    
                await _cekSenetMuhasebeKoduDal.Update(cekSenetMuhasebeKodu);

            return new SuccessResult(CekSenetMuhasebeKoduMessages.Updated);
        }        

        //[SecuredAspect()]
        public async Task<IDataResult<CekSenetMuhasebeKodu>> Get()
        {
            return new SuccessDataResult<CekSenetMuhasebeKodu>(await _cekSenetMuhasebeKoduDal.GetFirst());
        }

    }
}
