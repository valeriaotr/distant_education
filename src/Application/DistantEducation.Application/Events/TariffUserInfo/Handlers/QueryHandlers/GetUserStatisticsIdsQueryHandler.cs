using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.QueryHandlers;

public class GetUserStatisticsIdsQueryHandler : IRequestHandler<GetUserStatisticsIdsQuery, List<string>>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public GetUserStatisticsIdsQueryHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<List<string>> Handle(GetUserStatisticsIdsQuery request, CancellationToken cancellationToken)
    {
        var infos = await _tariffUserInfoRepository.GetAllUserInfo(request.UserId);
        var statisticsIds = new List<string>();

        foreach (var info in infos)
        {
            statisticsIds.Add(info.GetStatisticsId());
        }

        return statisticsIds;
    }
}