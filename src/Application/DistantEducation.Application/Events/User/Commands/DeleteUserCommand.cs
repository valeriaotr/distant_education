using MediatR;

namespace DistantEducation.Application.Events.User.Commands;

public class DeleteUserCommand : IRequest
{
    public string UserId { get; set; }
    public DeleteUserCommand(string userId)
    {
        UserId = userId;
    }
}