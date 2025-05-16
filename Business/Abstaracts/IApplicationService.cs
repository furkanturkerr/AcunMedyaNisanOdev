using Business.DTOs.Requests;
using Business.DTOs.Requests.Application;
using Business.DTOs.Responses.Applicaton; 
namespace Business.Abstaracts;

public interface IApplicationService
{
    Task<List<GetAllApplicationsResponse>> GetAllAsync();
    Task<GetApplicationResponse> GetByIdAsync(int id);
    Task AddAsync(CreateApplicationRequest request);
    Task UpdateAsync(UpdateApplicationRequest request);
    Task DeleteAsync(DeleteApplicationRequest request);
}
