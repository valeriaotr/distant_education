using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistantEducation.Infrastructure.Persistence.Configurations;

public class TariffEntityConfiguration : IEntityTypeConfiguration<TariffEntity>
{
    public void Configure(EntityTypeBuilder<TariffEntity> builder)
    {
        builder.ToTable("Tariffs"); 
        builder.HasKey(t => t.Id); 
    }
}