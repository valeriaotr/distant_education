using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.Regisration;

public class UserRegisterResponseBaseDto : ResponseBase
{
    public string? UserId { get; set; }

    public UserRegisterResponseBaseDto(string? userId, HttpStatusCode statusCode, string message) : base(statusCode, message) 
    {
        UserId = userId;
        StatusCode = statusCode;
        Message = message;
    }
}