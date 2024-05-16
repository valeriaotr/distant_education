using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetUserStatisticsIdsQuery : IRequest<List<string>>
{
    public string UserId { get; set; }

    public GetUserStatisticsIdsQuery(string userId)
    {
        UserId = userId;
    }
}