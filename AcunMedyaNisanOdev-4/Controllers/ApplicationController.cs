using Business.Abstaracts;
using Business.DTOs.Requests.Application;
using Business.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Concretes;

namespace AcunMedyaNisanOdev_4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var applications = await _applicationService.GetAllAsync();
        return Ok(applications);
    }

    //Controller ➝ ApplicationService.GetAllAsync() metodunu çağırır.

    //ApplicationService ➝ ApplicationRepository.GetAllAsync() metodunu çağırır.

    //ApplicationRepository ➝ Entity Framework’ün DbContext.Applications.ToListAsync() komutunu kullanır.

    //EF Core, veritabanına SELECT* FROM Applications gibi bir sorgu yollar.

    //Veriler List<Application> olarak döner.

    //Controller Ok(veri) diyerek JSON olarak API cevabı döner.

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var application = await _applicationService.GetByIdAsync(id);
        if (application == null)
            return NotFound();
        return Ok(application);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateApplicationRequest request)
    {
        await _applicationService.AddAsync(request);
        return StatusCode(201); // Created
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateApplicationRequest request)
    {
        await _applicationService.UpdateAsync(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteRequest = new DeleteApplicationRequest { Id = id };
        await _applicationService.DeleteAsync(deleteRequest); 
        return NoContent();
    }
}


