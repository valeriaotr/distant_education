using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistantEducation.Infrastructure.Persistence.Configurations;

public class TariffUserInfoEntityConfiguration : IEntityTypeConfiguration<TariffUserInfoEntity>
{
    public void Configure(EntityTypeBuilder<TariffUserInfoEntity> builder)
    {
        builder.ToTable("TariffUserInfos"); 
        builder.HasKey(t => t.Id); 
    }
}