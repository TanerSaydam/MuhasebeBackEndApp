using Business.Repositories.BorcSenetiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorcSenetisController : ControllerBase
    {
        private readonly IBorcSenetiService _borcSenetiService;

        public BorcSenetisController(IBorcSenetiService borcSenetiService)
        {
            _borcSenetiService = borcSenetiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(BorcSeneti borcSeneti)
        {
            var result = await _borcSenetiService.Add(borcSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(BorcSeneti borcSeneti)
        {
            var result = await _borcSenetiService.Update(borcSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(BorcSeneti borcSeneti)
        {
            var result = await _borcSenetiService.Delete(borcSeneti);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _borcSenetiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _borcSenetiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
