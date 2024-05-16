using DistantEducation.Application.Models.TariffUserInfo;
using MediatR;

namespace DistantEducation.Application.Events.TariffUserInfo.Commands;

public class AddTariffToUserCommand : IRequest<TariffUserInfoModel>
{
    public string UserId { get; set; }
    public string TariffId { get; set; }
    public int Validity { get; set; }
    public string CourseId { get; set; }

    public AddTariffToUserCommand(string userId, string tariffId, int validity, string courseId)
    {
        UserId = userId;
        TariffId = tariffId;
        Validity = validity;
        CourseId = courseId;
    }
}