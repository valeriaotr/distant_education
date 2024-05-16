using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.PersonalStatistics.Queries;
using DistantEducation.Application.Exceptions;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Handlers.QueryHandlers;

public class GetSuccessTasksAmountQueryHandler : IRequestHandler<GetSuccessTasksAmountQuery,int>
{
    private readonly IPersonalStatisticsRepository _statisticsRepository;
    
    public GetSuccessTasksAmountQueryHandler(IPersonalStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }
    
    public async Task<int> Handle(GetSuccessTasksAmountQuery request, CancellationToken cancellationToken)
    {
        var statisticsModel = await _statisticsRepository.FindStatisticsById(request.StatisticsId);
        if (statisticsModel == null)
        {
            throw new NullStatisticsException($"Statistics with ID {request.StatisticsId} not found");
        }
        return statisticsModel.GetSuccessTasks();
    }
}