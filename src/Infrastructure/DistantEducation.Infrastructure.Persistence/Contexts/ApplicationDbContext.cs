using DistantEducation.Infrastructure.Persistence.Configurations;
using DistantEducation.Infrastructure.Persistence.Entity;
using Microsoft.EntityFrameworkCore;

namespace DistantEducation.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    
    public required DbSet<UserEntity> Users { get; set; }
    public required DbSet<TariffEntity> Tariffs { get; set; }
    public required DbSet<StudyMaterialEntity> Materials { get; set; }
    public required DbSet<CourseEntity> Courses { get; set; }
    public required DbSet<PersonalStatisticsEntity> Statistics { get; set; }
    public required DbSet<TariffUserInfoEntity> TariffUserInfos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<UserEntity>()
            .ToTable("Users", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<TariffEntity>()
            .ToTable("Tariffs", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<TariffUserInfoEntity>()
            .ToTable("TariffUserInfo", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<CourseEntity>()
            .ToTable("Courses", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<PersonalStatisticsEntity>()
            .ToTable("Statistics", t => t.ExcludeFromMigrations());
        modelBuilder.Entity<StudyMaterialEntity>()
            .ToTable("Materials", t => t.ExcludeFromMigrations());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=ep-mute-sun-a2woi1rv.eu-central-1.aws.neon.tech;Port=5432;User Id=entityfrm;Password=pP3VJsoAcX2q;Database=distanteducation");
    }
}