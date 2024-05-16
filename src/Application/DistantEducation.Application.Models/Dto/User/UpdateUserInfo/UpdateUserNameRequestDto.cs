using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.UpdateUserInfo;

public class UpdateUserNameRequestDto : ResponseBase
{
    public string UserId { get; set; }
    public string NewName { get; set; }

    public UpdateUserNameRequestDto(string userId, string newName, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        UserId = userId;
        NewName = newName;
        StatusCode = statusCode;
        Message = message;
    }
}