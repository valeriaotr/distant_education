using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Commands;

public class DeleteUserInfoCommand : IRequest
{
    public string InfoId { get; set; }

    public DeleteUserInfoCommand(string infoId)
    {
        InfoId = infoId;
    }
}