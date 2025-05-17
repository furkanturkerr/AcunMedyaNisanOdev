using AutoMapper;
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
    private readonly IMapper _mapper;

    public BootcampManager(IBootcampRepository bootcampRepository, IMapper mapper)
    {
        _bootcampRepository = bootcampRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllBootcampResponse>> GetAllAsync()
    {
        var bootcamps = await _bootcampRepository.GetAllAsync();
        return _mapper.Map<List<GetAllBootcampResponse>>(bootcamps);
    }

    public async Task<GetBootcampResponse> GetByIdAsync(int id)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == id);
        return _mapper.Map<GetBootcampResponse>(bootcamp);
    }


    public async Task AddAsync(CreateBootcampRequest request)
    {
        var bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.AddAsync(bootcamp);
    }

    public async Task UpdateAsync(UpdateBootcampRequest request)
    {
        var bootcamp = _mapper.Map<Bootcamp>(request);
        await _bootcampRepository.UpdateAsync(bootcamp);
    }

    public async Task DeleteAsync(DeleteBootcampRequest request)
    {
        var bootcamp = await _bootcampRepository.GetAsync(b => b.Id == request.Id);
        if (bootcamp != null)
            await _bootcampRepository.DeleteAsync(bootcamp);
    }
}