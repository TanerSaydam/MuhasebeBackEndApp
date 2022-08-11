using Business.Repositories.BankaHesabiRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaHesabisController : ControllerBase
    {
        private readonly IBankaHesabiService _bankaHesabiService;

        public BankaHesabisController(IBankaHesabiService bankaHesabiService)
        {
            _bankaHesabiService = bankaHesabiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(BankaHesabiDto bankaHesabiDto)
        {
            var result = await _bankaHesabiService.Add(bankaHesabiDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(BankaHesabiDto bankaHesabiDto)
        {
            var result = await _bankaHesabiService.Update(bankaHesabiDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{bankaHesabiId}")]
        public async Task<IActionResult> Delete(int bankaHesabiId)
        {
            var result = await _bankaHesabiService.Delete(bankaHesabiId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _bankaHesabiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
        [HttpGet("[action]")]
        public ActionResult GetBankaHesabiList()
        {
            var result = _bankaHesabiService.GetBankaHesabiList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bankaHesabiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
