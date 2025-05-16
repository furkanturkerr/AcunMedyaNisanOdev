using Business.Abstaracts;
using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Responses.Bootcamp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaNisanOdev_4.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BootcampController : ControllerBase
{
    private readonly IBootcampService _bootcampService;

    public BootcampController(IBootcampService bootcampService)
    {
        _bootcampService = bootcampService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bootcamps = await _bootcampService.GetAllAsync();
        return Ok(bootcamps);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var bootcamp = await _bootcampService.GetByIdAsync(id);
        if (bootcamp == null)
            return NotFound();
        return Ok(bootcamp);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBootcampRequest request)
    {
        await _bootcampService.AddAsync(request);
        return StatusCode(201);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateBootcampRequest request)
    {
        await _bootcampService.UpdateAsync(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteRequest = new DeleteBootcampRequest { Id = id };
        await _bootcampService.DeleteAsync(deleteRequest);
        return NoContent();
    }
}