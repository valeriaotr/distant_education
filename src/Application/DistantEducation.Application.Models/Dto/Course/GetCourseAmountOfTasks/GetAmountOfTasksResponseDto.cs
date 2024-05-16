using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.GetCourseAmountOfTasks;

public class GetAmountOfTasksResponseDto : ResponseBase
{
    public int AmountOfTasks { get; set; }
    public new HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; }

    public GetAmountOfTasksResponseDto(int amountOfTasks, HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        AmountOfTasks = amountOfTasks;
        StatusCode = statusCode;
        Message = message;
    }
}