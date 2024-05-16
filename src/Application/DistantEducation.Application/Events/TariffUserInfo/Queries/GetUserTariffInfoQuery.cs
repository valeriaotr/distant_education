using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetUserTariffInfoQuery : IRequest<TariffUserInfoModel>
{
    public string UserId { get; set; }

    public GetUserTariffInfoQuery(string userId)
    {
        UserId = userId;
    }
}