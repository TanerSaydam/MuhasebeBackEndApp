using Business.Repositories.MusteriSenetiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriSenetisController : ControllerBase
    {
        private readonly IMusteriSenetiService _musteriSenetiService;

        public MusteriSenetisController(IMusteriSenetiService musteriSenetiService)
        {
            _musteriSenetiService = musteriSenetiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(MusteriSeneti musteriSeneti)
        {
            var result = await _musteriSenetiService.Add(musteriSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(MusteriSeneti musteriSeneti)
        {
            var result = await _musteriSenetiService.Update(musteriSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(MusteriSeneti musteriSeneti)
        {
            var result = await _musteriSenetiService.Delete(musteriSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _musteriSenetiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _musteriSenetiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
