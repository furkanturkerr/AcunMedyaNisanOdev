using Business.DTOs.Requests.Application;
using Business.DTOs.Requests;
using Business.DTOs.Responses.Applicaton;
using Repositories.Abstracts;
using Entities;

namespace Business.Concretes;

public class ApplicationManager
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationManager(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<List<GetAllApplicationsResponse>> GetAllAsync()
    {
        var applications = await _applicationRepository.GetAllAsync();
        return applications.Select(a => new GetAllApplicationsResponse
        {
            Id = a.Id,
            ApplicantId = a.ApplicantId,
            BootcampId = a.BootcampId,
            ApplicationState = a.ApplicationState.ToString()
        }).ToList();
    }

    public async Task<GetApplicationResponse> GetByIdAsync(int id)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == id);
        if (application == null)
            throw new Exception("Application not found");

        return new GetApplicationResponse
        {
            Id = application.Id,
            ApplicantId = application.ApplicantId,
            BootcampId = application.BootcampId,
            ApplicationState = application.ApplicationState.ToString()
        };
    }

    public async Task AddAsync(CreateApplicationRequest request)
    {
        var application = new Application
        {
            ApplicantId = request.ApplicantId,
            BootcampId = request.BootcampId,
            ApplicationState = request.ApplicationState
        };

        await _applicationRepository.AddAsync(application);
    }

    public async Task UpdateAsync(UpdateApplicationRequest request)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
        if (application == null)
            throw new Exception("Application not found");

        application.ApplicationState = request.ApplicationState;
        await _applicationRepository.UpdateAsync(application);
    }

    public async Task DeleteAsync(DeleteApplicationRequest request)
    {
        var application = await _applicationRepository.GetAsync(a => a.Id == request.Id);
        if (application == null)
            throw new Exception("Application not found");

        await _applicationRepository.DeleteAsync(application);
    }
}
