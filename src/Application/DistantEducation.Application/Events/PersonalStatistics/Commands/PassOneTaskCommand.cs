using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Commands;

public class PassOneTaskCommand : IRequest
{
    public string StatisticsId { get; set; }

    public PassOneTaskCommand(string statisticsId)
    {
        StatisticsId = statisticsId;
    }
}