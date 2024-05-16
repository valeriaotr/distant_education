using DistantEducation.Application.Abstractions.Persistence.Repositories.Interfaces;
using DistantEducation.Application.Events.TariffUserInfo.Queries;
using DistantEducation.Application.Exceptions.TariffUserInfo;
using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Handlers.QueryHandlers;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, TariffUserInfoModel>
{
    private readonly ITariffUserInfoRepository _tariffUserInfoRepository;

    public GetUserInfoQueryHandler(ITariffUserInfoRepository tariffUserInfoRepository)
    {
        _tariffUserInfoRepository = tariffUserInfoRepository;
    }

    public async Task<TariffUserInfoModel> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        var model = await _tariffUserInfoRepository.GetUserInfoById(request.UserId);
        if (model == null)
        {
            throw new NullTariffUserInfoException($"No info for user with ID {request.UserId}");
        }

        return model;
    }
}