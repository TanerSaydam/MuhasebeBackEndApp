using Business.Repositories.FaturaDetayiRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaDetayisController : ControllerBase
    {
        private readonly IFaturaDetayiService _faturaDetayiService;

        public FaturaDetayisController(IFaturaDetayiService faturaDetayiService)
        {
            _faturaDetayiService = faturaDetayiService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(FaturaDetayi faturaDetayi)
        {
            var result = await _faturaDetayiService.Add(faturaDetayi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(FaturaDetayi faturaDetayi)
        {
            var result = await _faturaDetayiService.Update(faturaDetayi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(FaturaDetayi faturaDetayi)
        {
            var result = await _faturaDetayiService.Delete(faturaDetayi);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _faturaDetayiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _faturaDetayiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
