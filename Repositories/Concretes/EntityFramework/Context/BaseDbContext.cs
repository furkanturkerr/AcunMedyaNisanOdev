using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Repositories.Concretes.EntityFramework.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options)
            : base(options)
        {
        }

        // Veritabanı tabloları
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Assembly içindeki IEntityTypeConfiguration implementasyonlarını uygular
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Tüm ilişkilerde silme davranışı Cascade olacak şekilde ayarla
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
