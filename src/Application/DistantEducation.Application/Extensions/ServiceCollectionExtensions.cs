using System.Reflection;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DistantEducation.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        // TODO: add services
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IPersonalStatisticsService, PersonalStatisticsService>();
        collection.AddScoped<ITariffService, TariffService>();
        
        collection.AddScoped<ICourseService, CourseService>();
        collection.AddScoped<IStudyMaterialsService, StudyMaterialService>();
        collection.AddScoped<ITariffUserInfoService, TariffUserInfoService>();
        collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return collection;
    }
}