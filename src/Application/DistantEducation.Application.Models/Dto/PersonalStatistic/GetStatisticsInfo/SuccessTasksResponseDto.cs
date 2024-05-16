using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.PersonalStatistic.GetStatisticsInfo;

public class SuccessTasksResponseDto : ResponseBase
{
    public int SuccessTasks { get; set; }

    public SuccessTasksResponseDto(int successTasks, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        SuccessTasks = successTasks;
    }
}