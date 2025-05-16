using Business.Abstaracts;
using Business.Abstracts;
using Business.DTOs.Requests.Blacklist;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blacklists = await _blacklistService.GetAllAsync();
            return Ok(blacklists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blacklist = await _blacklistService.GetByIdAsync(id);
            if (blacklist == null)
                return NotFound();
            return Ok(blacklist);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlacklistRequest request)
        {
            await _blacklistService.AddAsync(request);
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlacklistRequest request)
        {
            await _blacklistService.UpdateAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blacklistService.DeleteAsync(id);
            return NoContent();
        }
    }
}
