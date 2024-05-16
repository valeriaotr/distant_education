using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.GetUserInfo;

public class UserResponseBaseDto : ResponseBase
{
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? TariffId { get; set; }
    public string? StatisticsId { get; set; }

    public UserResponseBaseDto(string userId, string? firstName, string? lastName, string? tariffId, 
        string statisticsId, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        TariffId = tariffId;
        StatisticsId = statisticsId;
        StatusCode = statusCode;
        Message = message;
    }
}