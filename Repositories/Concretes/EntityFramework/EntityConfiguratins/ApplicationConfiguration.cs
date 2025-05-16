using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfiguratins;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
               .HasColumnName("Id")
               .IsRequired();

        builder.Property(a => a.ApplicantId)
               .HasColumnName("ApplicantId")
               .IsRequired();

        builder.Property(a => a.BootcampId)
               .HasColumnName("BootcampId")
               .IsRequired();

        builder.Property(a => a.ApplicationState)
               .HasColumnName("ApplicationState")
               .IsRequired();

        // Navigation property - Application has one Bootcamp, Bootcamp has many Applications
        builder.HasOne(a => a.Bootcamp)
               .WithMany(b => b.Applications)
               .HasForeignKey(a => a.BootcampId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
