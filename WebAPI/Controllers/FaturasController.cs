using Business.Repositories.FaturaRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturasController : ControllerBase
    {
        private readonly IFaturaService _faturaService;

        public FaturasController(IFaturaService faturaService)
        {
            _faturaService = faturaService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Fatura fatura)
        {
            var result = await _faturaService.Add(fatura);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(Fatura fatura)
        {
            var result = await _faturaService.Update(fatura);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(Fatura fatura)
        {
            var result = await _faturaService.Delete(fatura);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _faturaService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _faturaService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
