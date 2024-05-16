using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.User.GetUserInfo;

public class AllTariffsUserInfoResponseDto : ResponseBase
{
    public string? UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<string?> TariffsIds { get; set; }
    public List<string?> StatisticsIds { get; set; }

    public AllTariffsUserInfoResponseDto(string userId, string? firstName, string? lastName, List<string?> tariffsIds, List<string?> statisticsIds, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        TariffsIds = tariffsIds;
        StatisticsIds = statisticsIds;
        StatusCode = statusCode;
        Message = message;
    }
}