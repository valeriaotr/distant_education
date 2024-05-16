using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetAllUserInfoQuery : IRequest<List<TariffUserInfoModel>>
{
    public string UserId { get; set; }

    public GetAllUserInfoQuery(string userId)
    {
        UserId = userId;
    }
}