using MediatR;

namespace DistantEducation.Application.Events.User.Commands;

public class UpdateFirstNameCommand : IRequest
{
    public string UserId { get; set; }
    public string NewName { get; set; }
    
    public UpdateFirstNameCommand(string userId, string newName)
    {
        UserId = userId;
        NewName = newName;
    }
}