using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories.Concretes.EntityFramework.Context
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }

        // Sadece DbContextOptions<BaseDbContext> alan constructor
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.Cascade;
            }
        }
    }
}
