using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.HesapPlaniRepository
{
    public interface IHesapPlaniService
    {
        Task<IResult> Add(HesapPlani hesapPlani);
        Task<IResult> TekDuzenHesapPlaniOlustur();
        Task<IResult> Update(HesapPlani hesapPlani);
        Task<IResult> Delete(int hesapPlaniId);
        Task<IResult> DeleteByHesapPlaniModule(int hesapPlaniId);
        Task<IDataResult<List<HesapPlani>>> GetList();
        Task<IDataResult<HesapPlani>> GetById(int id);
        IDataResult<List<MizanDto>> GetTarihAralikliMizan(string tarih1, string tarih2);
        IDataResult<List<MizanDto>> GetKasaList();
        Task<IResult> HesapPlaniKoduVarMiKontrolEt(string hesapPlaniKodu);
    }
}
