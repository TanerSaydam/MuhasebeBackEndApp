using Business.Repositories.HesapPlaniRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HesapPlanisController : ControllerBase
    {
        private readonly IHesapPlaniService _hesapPlaniService;

        public HesapPlanisController(IHesapPlaniService hesapPlaniService)
        {
            _hesapPlaniService = hesapPlaniService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(HesapPlani hesapPlani)
        {
            var result = await _hesapPlaniService.Add(hesapPlani);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> TekDuzenHesapPlaniOlustur()
        {
            var result = await _hesapPlaniService.TekDuzenHesapPlaniOlustur();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(HesapPlani hesapPlani)
        {
            var result = await _hesapPlaniService.Update(hesapPlani);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{hesapPlaniId}")]
        public async Task<IActionResult> Delete(int hesapPlaniId)
        {
            var result = await _hesapPlaniService.DeleteByHesapPlaniModule(hesapPlaniId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _hesapPlaniService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public IActionResult GetTarihAralikliMizan(string tarih1, string tarih2)
        {
            var result = _hesapPlaniService.GetTarihAralikliMizan(tarih1,tarih2);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _hesapPlaniService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
