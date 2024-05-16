using DistantEducation.Application.Models.PersonalStatistics;

namespace DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;

public interface IPersonalStatisticsRepository
{
    Task<PersonalStatisticsModel?> FindStatisticsById(string statisticsId);
    Task AddStatistics(PersonalStatisticsModel personalStatisticsModel);
    Task UpdateStatisticsSuccessTasks(PersonalStatisticsModel statisticsModel);
    Task DeleteStatistics(string statisticsId); 
}