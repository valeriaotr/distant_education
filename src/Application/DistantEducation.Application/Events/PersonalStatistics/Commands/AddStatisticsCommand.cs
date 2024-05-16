using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Commands;

public class AddStatisticsCommand : IRequest
{
    public string Id { get; set; }
    public int AmountOfTasks { get; set; }

    public AddStatisticsCommand(string id, int amountOfTasks)
    {
        Id = id;
        AmountOfTasks = amountOfTasks;
    }
}