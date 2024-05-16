using DistantEducation.Application.Models.PersonalStatistics;

namespace DistantEducation.Application.Contracts.ServicesInterfaces;

public interface IPersonalStatisticsService
{
    Task AddStatistics(string id, int amountOfTasks);
    Task<PersonalStatisticsModel?> GetStatistics(string statisticsId);
    Task<int> GetSuccessTasksAmountAsync(string statisticsId);
    Task<int> GetCommonTasksAmountAsync(string statisticsId);
    Task PassOneTaskAsync(string statisticsId);
    Task<double> CountPercentageAsync(string statisticsId);
}