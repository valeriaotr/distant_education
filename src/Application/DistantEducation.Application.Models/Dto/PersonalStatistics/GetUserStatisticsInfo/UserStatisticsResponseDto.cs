using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;
using DistantEducation.Application.Models.Dto.GetUserStatisticsInfo;

namespace DistantEducation.Application.Models.Dto.PersonalStatistics.GetUserStatisticsInfo;

public class UserStatisticsResponseDto : ResponseBase
{
    public List<StatisticsInfoDto> StatisticsInfo { get; set; }
    public PersonalStatistic.GetUserStatisticsInfo.UserStatisticsResponseDto ResponseDto;

    public UserStatisticsResponseDto(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
    }
}