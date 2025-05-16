using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Responses.Blacklist;

namespace Business.Abstaracts;

public interface IApplicationService
{
    Task<List<GetAllBlacklistsResponse>> GetAllAsync();
    Task<GetBlacklistResponse> GetByIdAsync(int id);
    Task AddAsync(CreateBlacklistRequest request);
    Task UpdateAsync(UpdateBlacklistRequest request);
    Task DeleteAsync(DeleteBlacklistRequest request);
}
