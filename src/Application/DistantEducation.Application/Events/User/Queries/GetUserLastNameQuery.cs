using MediatR;

namespace DistantEducation.Application.Events.User.Queries;

public class GetUserLastNameQuery : IRequest<string>
{
    public string UserId { get; set; }
    public GetUserLastNameQuery(string userId)
    {
        UserId = userId;
    }
}