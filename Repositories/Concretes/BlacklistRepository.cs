using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.Context;

namespace Repositories.Concretes;

public class BlacklistRepository : EfRepositoryBase<Blacklist, BaseDbContext>, IBlacklistRepository
{
    public BlacklistRepository(BaseDbContext context) : base(context)
    {
    }
}
