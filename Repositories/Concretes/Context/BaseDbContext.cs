using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Repositories.Concretes.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
            : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        // Veritabanı tabloları
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }

        // Model konfigürasyonlarını uygula
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Assembly içindeki IEntityTypeConfiguration'ları uygular
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Bütün ilişkilerde silme davranışını "Cascade" yapar
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
