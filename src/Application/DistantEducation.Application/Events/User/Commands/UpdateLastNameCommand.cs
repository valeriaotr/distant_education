using MediatR;

namespace DistantEducation.Application.Events.User.Commands;

public class UpdateLastNameCommand : IRequest
{
    public string UserId { get; set; }
    public string NewLastName { get; set; }
    
    public UpdateLastNameCommand(string userId, string newLastName)
    {
        UserId = userId;
        NewLastName = newLastName;
    }
}