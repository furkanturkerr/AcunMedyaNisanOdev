using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfiguratins;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamp");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

        builder.Property(x => x.StartDate).HasColumnName("StartDate").IsRequired();

        builder.Property(x => x.EndDate).HasColumnName("EndDate").IsRequired();

        builder.Property(x => x.BootcampState).HasColumnName("BootcampState").IsRequired();

        builder.HasMany(b => b.Applications)
       .WithOne(a => a.Bootcamp)
       .HasForeignKey(a => a.BootcampId)
       .OnDelete(DeleteBehavior.Cascade);
    }
}
