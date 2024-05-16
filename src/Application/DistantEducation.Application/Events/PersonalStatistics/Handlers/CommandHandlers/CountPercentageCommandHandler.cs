using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.PersonalStatistics.Commands;
using DistantEducation.Application.Exceptions;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Handlers.CommandHandlers;

public class CountPercentageCommandHandler : IRequestHandler<CountPercentageCommand, double>
{
    private readonly IPersonalStatisticsRepository _statisticsRepository;
    
    public CountPercentageCommandHandler(IPersonalStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public async Task<double> Handle(CountPercentageCommand request, CancellationToken cancellationToken)
    {
        var statistics = await _statisticsRepository.FindStatisticsById(request.StatisticsId);
        
        if (statistics == null)
        {
            throw new NullStatisticsException($"Statistics with ID {request.StatisticsId} not found");
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