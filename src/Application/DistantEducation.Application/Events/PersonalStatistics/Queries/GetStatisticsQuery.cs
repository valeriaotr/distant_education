using DistantEducation.Application.Models.PersonalStatistics;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Queries;

public class GetStatisticsQuery : IRequest<PersonalStatisticsModel>
{
    public string StatisticsId { get; set; }

    public GetStatisticsQuery(string statisticsId)
    {
        StatisticsId = statisticsId;
    }
}