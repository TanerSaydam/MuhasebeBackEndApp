using Business.Repositories.BorcCekiHareketRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorcCekiHareketsController : ControllerBase
    {
        private readonly IBorcCekiHareketService _borcCekiHareketService;

        public BorcCekiHareketsController(IBorcCekiHareketService borcCekiHareketService)
        {
            _borcCekiHareketService = borcCekiHareketService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(BorcCekiHareket borcCekiHareket)
        {
            var result = await _borcCekiHareketService.Add(borcCekiHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(BorcCekiHareket borcCekiHareket)
        {
            var result = await _borcCekiHareketService.Update(borcCekiHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(BorcCekiHareket borcCekiHareket)
        {
            var result = await _borcCekiHareketService.Delete(borcCekiHareket);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _borcCekiHareketService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _borcCekiHareketService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
