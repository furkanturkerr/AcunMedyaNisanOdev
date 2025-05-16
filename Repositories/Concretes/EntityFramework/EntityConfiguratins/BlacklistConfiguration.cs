using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfiguratins;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    void IEntityTypeConfiguration<Blacklist>.Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("BlackList");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Reason).HasColumnName("Reason").IsRequired();

        builder.Property(x => x.Date).HasColumnName("Date").IsRequired();

        builder.Property(x => x.ApplicantId).HasColumnName("ApplicantId").IsRequired();
    }
}