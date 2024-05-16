using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.PersonalStatistics.Commands;
using DistantEducation.Application.Exceptions;
using DistantEducation.Application.Models.PersonalStatistics;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Handlers.CommandHandlers;

public class PassOneTaskCommandHandler : IRequestHandler<PassOneTaskCommand>
{
    private readonly IPersonalStatisticsRepository _statisticsRepository;
    
    public PassOneTaskCommandHandler(IPersonalStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public async Task Handle(PassOneTaskCommand request, CancellationToken cancellationToken)
    {
        var statistics = _statisticsRepository.FindStatisticsById(request.StatisticsId).Result;
        if (statistics == null)
        {
            throw new NullStatisticsException($"Statistics with ID {request.StatisticsId} not found");
        }
        var newSuccessTasksModel = PersonalStatisticsModel.Builder()
            .Id(statistics.GetId())
            .SuccessTasks(statistics.GetSuccessTasks() + 1)
            .Build();
        await _statisticsRepository.UpdateStatisticsSuccessTasks(newSuccessTasksModel);
    }
}