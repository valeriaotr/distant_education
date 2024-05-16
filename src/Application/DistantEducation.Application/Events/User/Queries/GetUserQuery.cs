using DistantEducation.Application.Models.User;
using MediatR;

namespace DistantEducation.Application.Events.User.Queries;

public class GetUserQuery : IRequest<UserModel>
{
    public string UserId { get; set; }
    public GetUserQuery(string userId)
    {
        UserId = userId;
    }
}