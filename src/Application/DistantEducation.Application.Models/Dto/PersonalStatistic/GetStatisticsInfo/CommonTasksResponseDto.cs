using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.PersonalStatistic.GetStatisticsInfo;

public class CommonTasksResponseDto : ResponseBase
{
    public int CommonTasks { get; set; }

    public CommonTasksResponseDto(int commonTasks, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        CommonTasks = commonTasks;
    }
}