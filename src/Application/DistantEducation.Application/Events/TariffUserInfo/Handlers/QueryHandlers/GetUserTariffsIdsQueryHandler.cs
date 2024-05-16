using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using DistantEducation.Application.Exceptions.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.QueryHandlers;

public class GetUserTariffsIdsQueryHandler : IRequestHandler<GetUserTariffsIdsQuery, List<string>>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public GetUserTariffsIdsQueryHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<List<string>> Handle(GetUserTariffsIdsQuery request, CancellationToken cancellationToken)
    {
        var infos = await _tariffUserInfoRepository.GetAllUserInfo(request.UserId);

        var tariffIds = new List<string>();

        foreach (var info in infos)
        {
            tariffIds.Add(info.GetTariffId() ?? throw new NullTariffUserInfoException($"Null info with ID {info.GetTariffUserInfoId()}"));
        }
        
        return tariffIds;
    }
}