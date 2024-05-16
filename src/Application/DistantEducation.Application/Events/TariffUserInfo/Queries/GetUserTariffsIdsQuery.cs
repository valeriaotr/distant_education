using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Queries;

public class GetUserTariffsIdsQuery : IRequest<List<string>>
{
    public string UserId { get; set; }

    public GetUserTariffsIdsQuery(string userId)
    {
        UserId = userId;
    }
}