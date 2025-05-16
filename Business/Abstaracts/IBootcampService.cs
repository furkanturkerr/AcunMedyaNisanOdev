using Business.DTOs.Requests.Bootcamp;
using Business.DTOs.Responses.Bootcamp;

namespace Business.Abstaracts;

public interface IBootcampService
{
    Task<List<GetAllBootcampResponse>> GetAllAsync();
    Task<GetBootcampResponse> GetByIdAsync(int id);
    Task AddAsync(CreateBootcampRequest request);
    Task UpdateAsync(UpdateBootcampRequest request);
    Task DeleteAsync(DeleteBootcampRequest request);
}
