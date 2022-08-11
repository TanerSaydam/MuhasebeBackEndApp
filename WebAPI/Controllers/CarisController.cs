using AutoMapper;
using Business.Repositories.CariRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarisController : ControllerBase
    {
        private readonly ICariService _cariService;        

        public CarisController(ICariService cariService)
        {
            _cariService = cariService;            
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CariDto cariDto)
        {            
            var result = await _cariService.Add(cariDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CariDto cariDto)
        {            
            var result = await _cariService.Update(cariDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{cariId}")]
        public async Task<IActionResult> Delete(int cariId)
        {            
            var result = await _cariService.Delete(cariId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _cariService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public IActionResult GetCariList()
        {
            var result = _cariService.GetCariList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cariService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
