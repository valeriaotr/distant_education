using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistantEducation.Infrastructure.Persistence.Configurations;

public class MaterialEntityConfiguration : IEntityTypeConfiguration<StudyMaterialEntity>
{
    public void Configure(EntityTypeBuilder<StudyMaterialEntity> builder)
    {
        builder.ToTable("StudyMaterials"); 
        builder.HasKey(u => u.Id); 
    }
}