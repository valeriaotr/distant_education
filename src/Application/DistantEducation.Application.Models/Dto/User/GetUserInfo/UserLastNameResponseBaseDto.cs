using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.GetUserInfo;

public class UserLastNameResponseBaseDto : ResponseBase
{
    public string LastName { get; set; }

    public UserLastNameResponseBaseDto(string lastName, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        LastName = lastName;
    }
}