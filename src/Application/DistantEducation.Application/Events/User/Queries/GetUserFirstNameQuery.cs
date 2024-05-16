using MediatR;

namespace DistantEducation.Application.Events.User.Queries;

public class GetUserFirstNameQuery : IRequest<string>
{
    public string UserId { get; set; }
    public GetUserFirstNameQuery(string userId)
    {
        UserId = userId;
    }
}