using DistantEducation.Application.Abstractions.Persistence;
using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Infrastructure.Persistence.Contexts;
using DistantEducation.Infrastructure.Persistence.Migrations;
using DistantEducation.Infrastructure.Persistence.Plugins;
using DistantEducation.Infrastructure.Persistence.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistantEducation.Infrastructure.Persistence.Extensions;


public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddScoped<IPersistenceContext, PersistenceContext>();
        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<ICourseRepository, CourseRepository>();
        collection.AddScoped<IStudyMaterialRepository, StudyMaterialRepository>();
        
        collection.AddScoped<IPersonalStatisticsRepository, PersonalStatisticsRepository>();
        collection.AddScoped<ITariffRepository, TariffRepository>();
        collection.AddScoped<ITariffUserInfoRepository, TariffUserInfoRepository>();
        return collection;
    }

    public static IServiceCollection AddConnection(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
                //configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));  Server=localhost;Port=5432;Username=alexr;Database=gibdd
        return collection;
    }
}