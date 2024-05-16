using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistantEducation.Infrastructure.Persistence.Configurations;

public class StatisticsEntityConfiguration : IEntityTypeConfiguration<PersonalStatisticsEntity>
{
    public void Configure(EntityTypeBuilder<PersonalStatisticsEntity> builder)
    {
        builder.ToTable("PersonalStatistics"); 
        builder.HasKey(s => s.Id); 
    }
}