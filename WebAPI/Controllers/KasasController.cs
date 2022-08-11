using Business.Repositories.HesapPlaniRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasasController : ControllerBase
    {
        private readonly IHesapPlaniService _hesapPlaniService;

        public KasasController(IHesapPlaniService hesapPlaniService)
        {
            _hesapPlaniService = hesapPlaniService;
        }

        [HttpGet("[action]")]
        public IActionResult GetKasaList()
        {
            var result = _hesapPlaniService.GetKasaList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
