using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.Context;

namespace Repositories.Concretes;

public class BootcampRepository : EfRepositoryBase<Bootcamp, BaseDbContext>, IBootcampRepository
{
    public BootcampRepository(BaseDbContext context) : base(context)
    {
    }
}
