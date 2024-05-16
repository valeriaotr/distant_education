using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.GetUserInfo;

public class UserNameResponseBaseDto : ResponseBase
{
    public string Name { get; set; }

    public UserNameResponseBaseDto(string name, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        Name = name;
        StatusCode = statusCode;
        Message = message;
    }
}