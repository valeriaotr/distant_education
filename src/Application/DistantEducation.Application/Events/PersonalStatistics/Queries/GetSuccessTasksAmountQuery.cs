using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Queries;

public class GetSuccessTasksAmountQuery : IRequest<int>
{
    public string StatisticsId { get; set; }
    
    public GetSuccessTasksAmountQuery(string statisticsId)
    {
        StatisticsId = statisticsId;
    }
}