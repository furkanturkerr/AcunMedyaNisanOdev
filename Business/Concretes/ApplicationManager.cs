using Business.DTOs.Requests.Application;
using Business.DTOs.Requests;
using Business.DTOs.Responses.Applicaton;
using Repositories.Abstracts;
using Entities;
using Business.Abstaracts;
using AutoMapper;

namespace Business.Concretes;

public class ApplicationManager : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IMapper _mapper;

    public ApplicationManager(IApplicationRepository applicationRepository, IMapper mapper)
    {
        _applicationRepository = applicationRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllApplicationsResponse>> GetAllAsync()
    {
        var applications = await _applicationRepository.GetAllAsync();
        return _mapper.Map<List<GetAllApplicationsResponse>>(applications);
    }

    public async Task<GetApplicationResponse> GetByIdAsync(int id)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == id);
        return _mapper.Map<GetApplicationResponse>(application);
    }

    public async Task AddAsync(CreateApplicationRequest request)
    {
        var application = _mapper.Map<Application>(request);
        await _applicationRepository.AddAsync(application);
    }

    public async Task UpdateAsync(UpdateApplicationRequest request)
    {
        var applicant = _mapper.Map<Application>(request);
        await _applicationRepository.UpdateAsync(applicant);
    }

    public async Task DeleteAsync(DeleteApplicationRequest request)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
        if (application == null)
            await _applicationRepository.DeleteAsync(application);
    }
}
