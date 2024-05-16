using MediatR;

namespace DistantEducation.Application.Events.User.Commands;

public class UpdatePasswordCommand : IRequest
{
    public string UserId { get; set; }
    public string NewPassword { get; set; }

    public UpdatePasswordCommand(string userId, string newPassword)
    {
        UserId = userId;
        NewPassword = newPassword;
    }
}