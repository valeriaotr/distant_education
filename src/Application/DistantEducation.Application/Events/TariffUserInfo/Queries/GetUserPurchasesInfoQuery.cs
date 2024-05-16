using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetUserPurchasesInfoQuery : IRequest<List<TariffUserInfoModel>>
{
    public string UserId { get; set; }

    public GetUserPurchasesInfoQuery(string userId)
    {
        UserId = userId;
    }
}