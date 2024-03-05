using Business.Abstracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClaimsController : Controller
    {
        private readonly IClaimService _claimService;
        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _claimService.GetByIdAsync(id));
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _claimService.GetAllAsync());
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Claim claim)
        {
            return Ok(await _claimService.AddAsync(claim));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Claim claim)
        {
            return Ok(await _claimService.UpdateAsync(claim));
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            await _claimService.DeleteByIdAsync(id);
            return Ok("Claim deleted");
        }
    }
}

