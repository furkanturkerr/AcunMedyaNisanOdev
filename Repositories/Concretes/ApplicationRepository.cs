using Core.Repositories.EntityFramework;
using Entities;
using System;

namespace Repositories.Concretes;

public class ApplicationRepository : EfRepositoryBase<Application, AppDbContext>
{
}
