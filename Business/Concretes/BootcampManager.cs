using Business.Abstaracts;
using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Responses.Bootcamp;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes;

namespace Business.Concretes;

public class BootcampManager : IBootcampService
{
    private readonly IBootcampRepository _bootcampRepository;

    public BootcampManager(IBootcampRepository bootcampRepository)
    {
        _bootcampRepository = bootcampRepository;
    }

    public async Task<List<GetAllBootcampResponse>> GetAllAsync()
    {
        var bootcamps = await _bootcampRepository.GetAllAsync();
        return bootcamps.Select(b => new GetAllBootcampResponse
        {
            Id = b.Id,
            Name = b.Name,
            BootcampState = b.BootcampState.ToString()
        }).ToList();
    }

    public async Task<GetBootcampResponse> GetByIdAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetAsync(x => x.Id == id);

        if (bootcamp == null)
            throw new Exception("Bootcamp not found");

        return new GetBootcampResponse
        {
            Id = bootcamp.Id,
            Name = bootcamp.Name,
            StartDate = bootcamp.StartDate.ToShortDateString(),
            EndDate = bootcamp.EndDate.ToShortDateString(),
            BootcampState = bootcamp.BootcampState.ToString()
        };
    }

    public async Task AddAsync(CreateBootcampRequest request)
    {
        var bootcamp = new Bootcamp
        {
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            BootcampState = request.BootcampState
        };

        await _bootcampRepository.AddAsync(bootcamp);
    }

    public async Task UpdateAsync(UpdateBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetAsync(x => x.Id == request.Id);
        if (bootcamp == null)
            throw new Exception("Bootcamp not found");

        bootcamp.Name = request.Name;
        bootcamp.StartDate = request.StartDate;
        bootcamp.EndDate = request.EndDate;
        bootcamp.BootcampState = request.BootcampState;

        await _bootcampRepository.UpdateAsync(bootcamp);
    }

    public async Task DeleteAsync(DeleteBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetAsync(x => x.Id == request.Id);
        if (bootcamp == null)
            throw new Exception("Bootcamp not found");

        await _bootcampRepository.DeleteAsync(bootcamp);
    }
}