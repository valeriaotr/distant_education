using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetUserInfoQuery : IRequest<TariffUserInfoModel>
{
    public string UserId { get; set; }

    public GetUserInfoQuery(string userId)
    {
        UserId = userId;
    }
}