using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOperationClaim, UserOperationClaimDto>();
            CreateMap<UserOperationClaimDto, UserOperationClaim>();
            CreateMap<YevmiyeFisiDto, YevmiyeFisi>();
            CreateMap<YevmiyeFisi, YevmiyeFisiDto>();
            CreateMap<Cari, CariDto>();
            CreateMap<CariDto, Cari>();
            CreateMap<CekSenetMuhasebeKoduDto, CekSenetMuhasebeKodu>();
            CreateMap<CekSenetMuhasebeKodu, CekSenetMuhasebeKoduDto>();
            CreateMap<BorcCekiDto, BorcCeki>();
            CreateMap<BorcCeki, BorcCekiDto>();
        }
    }
}
