using AutoMapper;
using Business.Repositories.BorcCekiRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorcCekisController : ControllerBase
    {
        private readonly IBorcCekiService _borcCekiService;
        private readonly IMapper _mapper;

        public BorcCekisController(IBorcCekiService borcCekiService, IMapper mapper)
        {
            _borcCekiService = borcCekiService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(BorcCekiDto borcCekiDto)
        {
            var borcCeki = _mapper.Map<BorcCeki>(borcCekiDto);
            var result = await _borcCekiService.Add(borcCeki, borcCekiDto.VerilenFirmaId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
                

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(BorcCeki borcCeki)
        {
            var result = await _borcCekiService.Delete(borcCeki);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _borcCekiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _borcCekiService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
