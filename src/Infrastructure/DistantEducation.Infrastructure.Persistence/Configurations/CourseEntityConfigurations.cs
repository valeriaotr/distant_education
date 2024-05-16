using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistantEducation.Infrastructure.Persistence.Configurations;

public class CourseEntityConfigurations : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.ToTable("Courses"); 
        builder.HasKey(u => u.Id); 
    }
}