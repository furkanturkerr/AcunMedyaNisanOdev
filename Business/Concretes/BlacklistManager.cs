using AutoMapper;
using Business.Abstaracts;
using Business.Abstracts;
using Business.DTOs.Requests.Blacklist;
using Business.DTOs.Responses.Blacklist;
using Entities;
using Repositories.Abstracts;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBlacklistsResponse>> GetAllAsync()
        {
            var blacklists = await _blacklistRepository.GetAllAsync();
            return _mapper.Map<List<GetAllBlacklistsResponse>>(blacklists);
        }

        public async Task<GetBlacklistResponse> GetByIdAsync(int id)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
            return _mapper.Map<GetBlacklistResponse>(blacklist);
        }

        public async Task AddAsync(CreateBlacklistRequest request)
        {
            var blacklist = _mapper.Map<Blacklist>(request);

            await _blacklistRepository.AddAsync(blacklist);
        }

        public async Task UpdateAsync(UpdateBlacklistRequest request)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.Id == request.Id);
            if (blacklist == null)
                throw new Exception("Blacklist entry not found");

            _mapper.Map(request, blacklist);

            await _blacklistRepository.UpdateAsync(blacklist);
        }

        public async Task DeleteAsync(int id)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
            if (blacklist == null)
                throw new Exception("Blacklist record not found");

            await _blacklistRepository.DeleteAsync(blacklist);
        }
    }
}
