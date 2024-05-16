using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.QueryHandlers;

public class GetAllUserInfoQueryHandler : IRequestHandler<GetAllUserInfoQuery, List<TariffUserInfoModel>>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public GetAllUserInfoQueryHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<List<TariffUserInfoModel>> Handle(GetAllUserInfoQuery request, CancellationToken cancellationToken)
    {
        return await _tariffUserInfoRepository.GetAllUserInfo(request.UserId);
    }
}