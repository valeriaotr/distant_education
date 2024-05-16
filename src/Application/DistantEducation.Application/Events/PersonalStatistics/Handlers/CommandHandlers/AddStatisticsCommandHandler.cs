using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.PersonalStatistics.Commands;
using DistantEducation.Application.Models.PersonalStatistics;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Handlers.CommandHandlers;

public class AddStatisticsCommandHandler : IRequestHandler<AddStatisticsCommand>
{
    private readonly IPersonalStatisticsRepository _statisticsRepository;
    
    public AddStatisticsCommandHandler(IPersonalStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    
    public async Task Handle(AddStatisticsCommand request, CancellationToken cancellationToken)
    {
        var successTasks = 0;
        var model = new PersonalStatisticsModel(request.Id, successTasks, request.AmountOfTasks);
        await _statisticsRepository.AddStatistics(model);
    }
}