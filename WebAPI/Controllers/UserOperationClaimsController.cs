using AutoMapper;
using Business.Repositories.UserOperationClaimRepository;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IMapper _mapper;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService, IMapper mapper)
        {
            _userOperationClaimService = userOperationClaimService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(UserOperationClaimDto userOperationClaimDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimDto);
            var result = await _userOperationClaimService.Add(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UserOperationClaimDto userOperationClaimDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimDto);
            var result = await _userOperationClaimService.Update(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(UserOperationClaimDto userOperationClaimDto)
        {
            var userOperationClaim = _mapper.Map<UserOperationClaim>(userOperationClaimDto);
            var result = await _userOperationClaimService.Delete(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _userOperationClaimService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
