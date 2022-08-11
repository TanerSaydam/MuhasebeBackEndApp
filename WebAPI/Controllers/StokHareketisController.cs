using Business.Repositories.StokHareketiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokHareketisController : ControllerBase
    {
        private readonly IStokHareketiService _stokHareketiService;

        public StokHareketisController(IStokHareketiService stokHareketiService)
        {
            _stokHareketiService = stokHareketiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(StokHareketi stokHareketi)
        {
            var result = await _stokHareketiService.Add(stokHareketi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(StokHareketi stokHareketi)
        {
            var result = await _stokHareketiService.Update(stokHareketi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(StokHareketi stokHareketi)
        {
            var result = await _stokHareketiService.Delete(stokHareketi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _stokHareketiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _stokHareketiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
