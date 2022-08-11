using Business.Repositories.MusteriCekiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriCekisController : ControllerBase
    {
        private readonly IMusteriCekiService _musteriCekiService;

        public MusteriCekisController(IMusteriCekiService musteriCekiService)
        {
            _musteriCekiService = musteriCekiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(MusteriCeki musteriCeki)
        {
            var result = await _musteriCekiService.Add(musteriCeki);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(MusteriCeki musteriCeki)
        {
            var result = await _musteriCekiService.Update(musteriCeki);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(MusteriCeki musteriCeki)
        {
            var result = await _musteriCekiService.Delete(musteriCeki);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _musteriCekiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _musteriCekiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
