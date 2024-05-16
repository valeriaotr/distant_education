using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Queries;

public class GetCommonTasksAmountQuery : IRequest<int>
{
    public string StatisticsId { get; set; }
    
    public GetCommonTasksAmountQuery(string statisticsId)
    {
        StatisticsId = statisticsId;
    }
}