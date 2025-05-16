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

        public BlacklistManager(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task<List<GetBlacklistResponse>> GetAllAsync()
        {
            var blacklists = await _blacklistRepository.GetAllAsync();
            return blacklists.Select(b => new GetBlacklistResponse
            {
                Id = b.Id,
                ApplicantId = b.ApplicantId,
                Reason = b.Reason,
                Date = b.Date.ToString("yyyy-MM-dd")
            }).ToList();
        }

        public async Task<GetBlacklistResponse> GetByIdAsync(int id)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.Id == id);
            if (blacklist == null)
                throw new Exception("Blacklist record not found");

            return new GetBlacklistResponse
            {
                Id = blacklist.Id,
                ApplicantId = blacklist.ApplicantId,
                Reason = blacklist.Reason,
                Date = blacklist.Date.ToString("yyyy-MM-dd")
            };
        }

        public async Task AddAsync(CreateBlacklistRequest request)
        {
            var blacklist = new Blacklist
            {
                ApplicantId = request.ApplicantId,
                Reason = request.Reason,
                Date = DateTime.Now
            };

            await _blacklistRepository.AddAsync(blacklist);
        }

        public async Task UpdateAsync(UpdateBlacklistRequest request)
        {
            var blacklist = await _blacklistRepository.GetAsync(b => b.Id == request.Id);
            if (blacklist == null)
                throw new Exception("Blacklist record not found");

            blacklist.Reason = request.Reason;

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
