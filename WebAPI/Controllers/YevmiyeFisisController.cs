using AutoMapper;
using Business.Repositories.YevmiyeFisiRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YevmiyeFisisController : ControllerBase
    {
        private readonly IYevmiyeFisiService _yevmiyeFisiService;
        private readonly IMapper _mapper;

        public YevmiyeFisisController(IYevmiyeFisiService yevmiyeFisiService, IMapper mapper)
        {
            _yevmiyeFisiService = yevmiyeFisiService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(YevmiyeFisiDto yevmiyeFisiDto)
        {
            var yevmiyeFisi = _mapper.Map<YevmiyeFisi>(yevmiyeFisiDto);
            var result = await _yevmiyeFisiService.Add(yevmiyeFisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> ModulAdd(ModulYevmiyeFisiDto modulYevmiyeFisiDto)
        {            
            var result = await _yevmiyeFisiService.ModulAdd(modulYevmiyeFisiDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(YevmiyeFisiDto yevmiyeFisiDto)
        {
            var yevmiyeFisi = _mapper.Map<YevmiyeFisi>(yevmiyeFisiDto);
            var result = await _yevmiyeFisiService.Update(yevmiyeFisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(YevmiyeFisiDto yevmiyeFisiDto)
        {
            var yevmiyeFisi = _mapper.Map<YevmiyeFisi>(yevmiyeFisiDto);
            var result = await _yevmiyeFisiService.Delete(yevmiyeFisi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("[action]/{yevmiyeFisiNumarasi}")]
        public async Task<IActionResult> DeleteWithYevmiyeFisiNumarasi(string yevmiyeFisiNumarasi)
        {            
            var result = await _yevmiyeFisiService.DeleteWithYevmiyeFisiNumarasi(yevmiyeFisiNumarasi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _yevmiyeFisiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("[action]")]
        public IActionResult GetYevmiyeFisiWithHesapPlaniId(int hesapPlaniId, string tarih1, string tarih2)
        {
            var result = _yevmiyeFisiService.GetYevmiyeFisiWithHesapPlaniId(hesapPlaniId, tarih1, tarih2);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public IActionResult GetYevmiyeFisiList(string tarih1, string tarih2)
        {   
            var result = _yevmiyeFisiService.GetYevmiyeFisiList(tarih1, tarih2);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _yevmiyeFisiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
