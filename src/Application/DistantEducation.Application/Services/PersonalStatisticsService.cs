using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Contracts.ServicesInterfaces;
using DistantEducation.Application.Exceptions;
using DistantEducation.Application.Models.PersonalStatistics;

namespace DistantEducation.Application.Services;

public class PersonalStatisticsService : IPersonalStatisticsService
{
    private readonly IPersonalStatisticsRepository _personalStatisticsRepository;
    
    public PersonalStatisticsService(IPersonalStatisticsRepository personalStatisticsRepository)
    {
        _personalStatisticsRepository = personalStatisticsRepository;
    }

    public async Task AddStatistics(string id, int amountOfTasks)
    {
        var successTasks = 0;
        var model = new PersonalStatisticsModel(id, successTasks, amountOfTasks);
        await _personalStatisticsRepository.AddStatistics(model);
    }

    public async Task<PersonalStatisticsModel?> GetStatistics(string statisticsId)
    {
        var statistics = await _personalStatisticsRepository.FindStatisticsById(statisticsId);
        return statistics;
    }

    public async Task<int> GetSuccessTasksAmountAsync(string statisticsId)
    {
        var statistics = await _personalStatisticsRepository.FindStatisticsById(statisticsId);
        if (statistics == null)
        {
            throw new NullStatisticsException($"Statistics with ID {statisticsId} not found");
        }
        return statistics.GetSuccessTasks();
    }

    public async Task<int> GetCommonTasksAmountAsync(string statisticsId)
    {
        var statistics = await _personalStatisticsRepository.FindStatisticsById(statisticsId);
        if (statistics == null)
        {
            throw new NullStatisticsException($"Statistics with ID {statisticsId} not found");
        }
        return statistics.GetCommonAmountOfTasks();
    }

    public async Task PassOneTaskAsync(string statisticsId)
    {
        var statistic = _personalStatisticsRepository.FindStatisticsById(statisticsId).Result;
        if (statistic == null)
        {
            throw new NullStatisticsException($"Statistics with ID {statisticsId} not found");
        }
        var newCourse = PersonalStatisticsModel.Builder()
            .Id(statistic.GetId())
            .SuccessTasks(statistic.GetSuccessTasks() + 1)
            .Build();
        await _personalStatisticsRepository.UpdateStatisticsSuccessTasks(newCourse);
    }

    public async Task<double> CountPercentageAsync(string statisticsId)
    {
        var statistics = await _personalStatisticsRepository.FindStatisticsById(statisticsId);
        
        if (statistics == null)
        {
            throw new NullStatisticsException($"Statistics with ID {statisticsId} not found");
        }
        
        var tasksAmount = statistics.GetCommonAmountOfTasks();
        float successTasks = statistics.GetSuccessTasks();
        
        if (successTasks != 0)
        {
            return tasksAmount / successTasks * 100;
        }

        return 0;
    }
}