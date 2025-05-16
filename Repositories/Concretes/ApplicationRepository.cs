using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Context;



namespace Repositories.Concretes;

public class ApplicationRepository : EfRepositoryBase<Application, BaseDbContext>, IApplicationRepository
{
    public ApplicationRepository(BaseDbContext context) : base(context)
    {
    }
}
