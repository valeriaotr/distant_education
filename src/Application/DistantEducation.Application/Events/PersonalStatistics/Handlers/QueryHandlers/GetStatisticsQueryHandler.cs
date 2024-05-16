using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.PersonalStatistics.Queries;
using DistantEducation.Application.Exceptions;
using DistantEducation.Application.Models.PersonalStatistics;
using MediatR;

namespace DistantEducation.Application.Events.PersonalStatistics.Hadlers.QueryHandlers;

public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, PersonalStatisticsModel>
{
    private readonly IPersonalStatisticsRepository _statisticsRepository;

    public GetStatisticsQueryHandler(IPersonalStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public async Task<PersonalStatisticsModel> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
    {
        var statisticsModel = await _statisticsRepository.FindStatisticsById(request.StatisticsId);
        if (statisticsModel == null)
        {
            throw new NullStatisticsException($"Statistics with ID {request.StatisticsId} not found");
        }

        return statisticsModel;
    }
}