using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Commands;

public class CountPercentageCommand : IRequest<double>
{
    public string StatisticsId { get; set; }
    
    public CountPercentageCommand(string statisticsId)
    {
        StatisticsId = statisticsId;
    }
}