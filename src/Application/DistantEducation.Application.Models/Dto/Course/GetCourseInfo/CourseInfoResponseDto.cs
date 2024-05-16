using System.Net;
using DistantEducation.Application.Models.Dto.BaseResponse;

namespace DistantEducation.Application.Models.Dto.Course.GetCourseInfo;

public class CourseInfoResponseDto : ResponseBase
{
    public string? CourseId { get; set; }
    public string? Name { get; set; }
    public int AmountOfTasks { get; set; }
    public string TariffId { get; set; }
    public new HttpStatusCode StatusCode { get; set; }
    public new string Message { get; set; }

    public CourseInfoResponseDto(string courseId, string name, int amountOfTasks, string tariffId,
        HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        CourseId = courseId;
        Name = name;
        AmountOfTasks = amountOfTasks;
        TariffId = tariffId;
        StatusCode = statusCode;
        Message = message;
    }
    
}