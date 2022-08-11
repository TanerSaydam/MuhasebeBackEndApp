using AutoMapper;
using Business.Repositories.CekSenetMuhasebeKoduRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CekSenetMuhasebeKodusController : ControllerBase
    {
        private readonly ICekSenetMuhasebeKoduService _cekSenetMuhasebeKoduService;
        private readonly IMapper _mapper;

        public CekSenetMuhasebeKodusController(ICekSenetMuhasebeKoduService cekSenetMuhasebeKoduService, IMapper mapper)
        {
            _cekSenetMuhasebeKoduService = cekSenetMuhasebeKoduService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CekSenetMuhasebeKoduDto cekSenetMuhasebeKoduDto)
        {
            var cekSenetMuhasebeKodu = _mapper.Map<CekSenetMuhasebeKodu>(cekSenetMuhasebeKoduDto);
            var result = await _cekSenetMuhasebeKoduService.Update(cekSenetMuhasebeKodu);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }        

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var result = await _cekSenetMuhasebeKoduService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
