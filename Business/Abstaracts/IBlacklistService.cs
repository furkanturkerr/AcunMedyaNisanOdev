using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Responses.Blacklist;

namespace Business.Abstracts;

public interface IBlacklistService
{
    Task<List<GetBlacklistResponse>> GetAllAsync();
    Task<GetBlacklistResponse> GetByIdAsync(int id);
    Task AddAsync(CreateBlacklistRequest request);
    Task UpdateAsync(UpdateBlacklistRequest request);
    Task DeleteAsync(int id);
}
